# API migration checklist

## Resolved: ApiClient.cs JSON case-sensitivity bug (fixed)

`Etmam/Code/Api/ApiClient.cs`'s `ReadFromJsonAsync<T>()` calls originally passed no
`JsonSerializerOptions`, defaulting to case-*sensitive* property matching. ASP.NET Core controllers
serialize camelCase (`"id"`, `"name"`); deserializing that into PascalCase C# properties without
`JsonSerializerDefaults.Web` meant every response silently came back all-default (`0`/`null`/`""`)
— proven with a standalone repro (bare `JsonSerializerOptions()` gave `UserId=0, UserName=''`, `Web`
defaults gave the real values). This affected every `ApiClient` call, including the already-shipped
login and `ucProjectsMgt`. Fixed by adding a shared `JsonOptions = new(JsonSerializerDefaults.Web)`
and passing it everywhere. If you add a new `ReadFromJsonAsync`/`JsonContent.Create` call anywhere,
pass `ApiClient.JsonOptions` — don't call the bare overload.

## Second reference pattern: ucProjectsList.cs (a grid needing joined data)

Besides `ucProjectsMgt.cs` (§ below), `Etmam/Gui/ProjectsModule/ProjectsList/ucProjectsList.cs` is a
second worked example — for a grid needing a *different* field shape than `ProjectDto`'s wire
format (`FieldName="ProjectCode"` vs. the DTO's `Num`, etc.): add a small client-side POCO
(`Etmam/Code/Api/ProjectListItem.cs`) with `[JsonPropertyName(...)]` remapping onto the same
endpoint's response, rather than renaming either the grid's Designer columns or the API's DTO to
match. Also demonstrates pulling in a navigation property for display (`ClientName`/`ConsultantName`
via `.Include(p => p.Client)` in `ProjectsService.GetAllAsync`, materialize-then-map instead of
`.Select(p => ToDto(p))` to avoid depending on EF Core translating a method call to SQL).


Tracks the WinForms screens still calling `Data.DataContext.Shared` directly (straight to SQL
Server) instead of going through the new `Api` project. Generated from `grep -rl
"DataContext.Shared" Etmam --include="*.cs"`, grouped below by `Etmam/Gui/*` module (and
`Etmam/Code/*` for shared base/helper classes).

**Goal for this pass (confirmed 2026-08-24): reduce/eliminate `Etmam.exe`'s direct dependency on
the database** — every screen below needs a working local SQL connection profile provisioned
(`Data.DBSetting`, DPAPI-encrypted per Windows user) purely because it still calls
`DataContext.Shared`; moving a screen to the API removes that requirement for that screen.
**Server-side fine-grained permission enforcement (`PermNames.*` — per-store action grants,
workflow-definition access, screen-level access) is explicitly out of scope for this effort** and
stays a WinForms-only concern, deferred to a separate future security-hardening project. Don't
add it opportunistically while migrating a screen unless asked.

**`Web/` (the Blazor project) needs no migration work** — it has zero `DataContext` references
anywhere and was built API-native from the start (`Web/Services/EtmamApiClient.cs` is a plain
HTTP client against the same `Api` endpoints).

An earlier version of this doc undercounted (103 files, and 4 of those were stale — already
migrated) because its `grep` was scoped to `Etmam/Gui/*` and missed `Etmam/Code/*` plus a few
whole subfolders (`BOQMgt`, `DocumentsMgt/ConstructionInspectionRequest`,
`General/Masters/{Buildings,Floors,InspectionActivities,SecondaryDisciplines}`). Verified true
count as of 2026-08-24: **127 files**. Re-run the grep and diff against this doc at the start of
each future migration session rather than trusting it blindly — it has drifted before.

## Reference pattern (what "migrated" looks like)

The Auth + Projects slice is the template for every other file on this list:

- **Domain/Application/Infrastructure**: entities stay in `Core` unchanged; `Application`
  exposes DTOs + a service (`Application/Services/ProjectsService.cs`) coded against
  `IApplicationDbContext`; `Infrastructure/Persistence/ApplicationDbContext.cs` implements that
  interface over EF Core — nothing new needed per screen on this side unless the screen touches
  an entity/relationship EF Core hasn't been asked to serve yet.
- **Api**: add REST endpoints for whatever the screen needs (`Api/Controllers/ProjectsController.cs`
  is the template — `[Authorize]`, thin, delegates straight to the Application service).
- **Etmam**: add typed methods to `Etmam/Code/Api/ApiClient.cs` for the new endpoints. If the
  screen uses a `SimpleEditFormBase<T>`-style base (`Etmam/Gui/ProcurementModule/Common/`), write
  an `IDataHelper<T>`-shaped adapter like `Etmam/Code/Api/ApiProjectsDataHelper.cs` — **as a
  `static readonly` field, not an instance field** (the base constructor calls the overridden
  `Helper` property before derived-class instance field initializers run; see the comment on
  `frmProjectAddEdit.cs`'s `ApiHelper` field for why that matters). Replace the screen's
  `dc.<Entity>` calls with the new `ApiClient` calls.

## Known partially-migrated files

These three are **not** on the checklist below — they're already wired to the API for the
Auth/Projects flow, but each still has other, intentionally out-of-scope direct-`Data` calls that
a future session can pick up separately:

- `Etmam/Gui/MainPage/frmLogin.cs` — login itself is API-backed; the mandatory password-change
  refresh (`frmUpdatePassword`) still reads/writes via `Data` directly.
- `Etmam/Gui/General/ProjectsMgt/ucProjectsMgt.cs` — list/delete go through the API;
  `ProjectHasTransactions` (the pre-delete check across 10 other tables) still queries `Data`
  directly.
- `Etmam/Gui/General/ProjectsMgt/frmProjectAddEdit.cs` — Find/Add/Edit go through the API; the
  Client/Consultant lookup dropdowns and `OnAfterInsert`'s `UserProjectAccess` grants still use
  `Data` directly.

## Required before pointing this at any real database: backfill legacy NULL audit columns

Verified by actually restoring `Backup/Etmamdb-06-08-2026-8-02-22 AM.bak` locally and running the
API against it: `IBaseEntity.CreatedBy/UpdateBy/DeletionBy` (`int`) and `IsDelete` (`bool`) are
non-nullable in `Core`, but the *physical* columns are nullable, and real legacy rows (e.g. the
very first seeded admin user, which has no "creator") genuinely contain NULL there.
`Data/SqlDataHelper.cs`'s reader tolerates this silently (`if (... && !reader.IsDBNull(i))` — a
NULL column just leaves a freshly-constructed entity's property at its C# default of `0`/`false`).
EF Core has no equivalent: reading a NULL into a non-nullable `int`/`bool` throws
`SqlNullValueException`, and there is no mapping-side fix — confirmed empirically that
`IMutableProperty.IsNullable` flatly refuses to be set `true` on a non-nullable-CLR-type property,
converter or not ("only properties of nullable types can be marked nullable"). `AuthService.LoginAsync`
crashed on exactly this the first time it read a real `UsersList` row.

**The fix has to be a one-time data backfill, not a code change.** Before running the API (or any
EF Core migration) against a database carrying this legacy data, run something equivalent to:

```sql
UPDATE [TableName] SET
  [CreatedBy]  = ISNULL([CreatedBy], 0),
  [UpdateBy]   = ISNULL([UpdateBy], 0),
  [DeletionBy] = ISNULL([DeletionBy], 0),
  [IsDelete]   = ISNULL([IsDelete], 0)
WHERE [CreatedBy] IS NULL OR [UpdateBy] IS NULL OR [DeletionBy] IS NULL OR [IsDelete] IS NULL;
```

... for every table backing an `IBaseEntity` type (all of them ended up needing it in the restored
backup — 18 tables had at least one affected row). Once `InitialCreate` (or a successor migration)
is actually applied to a real database, it will also add `NOT NULL` constraints to these columns
going forward (matching what the C# model already asserts), so this should only ever be a one-time
cleanup for pre-existing data, not a recurring concern.

## Known EF Core model warning to revisit

`UsersList` carries the soft-delete query filter, but `ScheduleList`, `UserPermissionStatus`,
`UserProjectAccess`, `UserStoreAccess`, and `UserWorkflowAccess` have a **required** FK to it and
no filter of their own — EF Core logs a `10622` model-validation warning about this (a soft-deleted
user could leave a "required" navigation resolving to null on eager-loaded queries). Not a
blocker for anything in this slice since nothing here does that kind of `.Include()`, but worth a
deliberate decision (add filters to those five too, or make the navigations optional) before a
screen that does eager-load through `UsersList` gets migrated.

## Suggested phase order (see the session that wrote this note for full rationale)

1. **Cross-cutting prerequisites** (do once, unblocks everything below): the `10622` soft-delete
   filter fix above; a generic Attachments API (nothing exists yet — `AttachmentList.FileData`/
   `DrawingAttachment.FileData` are DB blobs already, just no upload/download endpoint); port
   `WorkflowService.GetPendingForUser` (only `GetActiveInstance`/`GetLatestInstance` exist so far).
2. **Simple master/lookup CRUD** (General/Masters, DrawingsMgt/Masters, Stores/Suppliers leftovers)
   — lowest risk, fastest, direct copy of the Units/Suppliers/Stores pattern.
3. **Reports/Excel import** — fold into whichever module owns the parent screen, not a standalone
   phase. All `*Printer.cs` classes are pure read (Find/GetBy → bind to an unchanged `XtraReport`).
   Excel importers loop existing single-entity Create calls, no bulk-insert endpoint needed.
   `frmBudgetImportWizard.cs`/`frmImportExportWizard.cs` are empty stubs — skip, don't "migrate" a
   no-op.
4. **Inventory transactional documents** (Items first, then OpeningBalance/Stocking, then
   MaterialIssued/Receive, then MaterialIssueReturn/Transfer/PurchaseReturn) — each needs a
   `WorkflowSync`-equivalent service wrapping `Infrastructure/Services/WorkflowService.cs`, same
   pattern `PurchaseRequestsService`/`PurchaseOrdersService`/`ConstructionInspectionRequestsService`
   already use.
5. **Procurement remaining documents** (PriceQuotation/RFQ/Negotiation/AwardRecommendation/
   TechnicalEvaluation, POAmendment) — most workflow-dense remaining cluster, do after step 4 has
   exercised the WorkflowSync pattern more.
6. **DocumentsMgt** (largest module: CIR remaining forms, DailyReport + sub-entities, DrawingsMgt
   core, MAR, Transmittals) — heaviest attachments consumer, do after step 1's attachments API is
   proven.
7. **BOQ + WorkflowMgt** — `ucMyWorkflowTasks.cs` needs step 1's `GetPendingForUser`. Check whether
   BOQMgt's other sub-features (Analysis/Approval/Comparison/Explorer/Reports/RevisionManagement —
   currently DB-free) are unbuilt placeholders before assuming they're out of scope.
8. **`Etmam/Code` base classes/helpers** — last, since they're referenced across every module above.

Verification per phase: deploy API-side changes before shipping a WinForms build that calls them
(purely additive, safe independently); check the NULL-audit-column backfill against production for
any newly-touched table; don't delete a screen's old `Data.DataContext.Shared` path immediately —
keep both until the API path has run in production for a burn-in period, especially for
workflow/transactional screens.

## Remaining files by module

Ordered per the phase plan above, not alphabetically. Checked box = migrated (no longer calls
`DataContext.Shared`).

### Cross-cutting prerequisites (no screen migration yet, but blocks most of the below)

- [x] `10622` soft-delete filter fix — done via `Navigation(...).IsRequired(false)` on the five
      `UsersList` FKs in `Infrastructure/Persistence/ApplicationDbContext.cs` (2026-08-24).
      Runtime-verified: EF model builds and executes a real query successfully (a login request
      reached `UsersList` with this change in place).
- [x] Attachments API for `AttachmentList` — `Application/Dtos/AttachmentDtos.cs`,
      `Application/Services/AttachmentsService.cs`, `Api/Controllers/AttachmentsController.cs`,
      `ApiClient.cs` additions (2026-08-24). Route registration + `[Authorize]` gating verified live
      (401 without a token, not 404). Full upload/download round-trip **not** live-tested — no
      valid login credentials were available in that session; verify this before relying on it in
      production. `DrawingAttachmentsController.cs` (for `DrawingAttachment`, used by
      `ucDrawingsAttachment.cs`) is **not** built yet — same pattern, do it when DrawingsMgt
      migrates (Phase 6/"do 6th" below).
- [x] `WorkflowService.GetPendingForUser` port — `Infrastructure/Services/WorkflowService.cs` +
      `Application/Interfaces/IWorkflowService.cs` (2026-08-24). Compiles; not yet exercised by a
      real caller (`ucMyWorkflowTasks.cs` hasn't migrated yet — Phase 7/"do 7th" below).

### General/Masters + DrawingsMgt/Masters + Stores/Suppliers (simple CRUD — do 2nd)

- [ ] `Etmam/Gui/General/Masters/Buildings/frmBuildingAddEdit.cs`
- [ ] `Etmam/Gui/General/Masters/Buildings/ucBuildingsList.cs`
- [ ] `Etmam/Gui/General/Masters/Disciplines/frmDisciplineAddEdit.cs`
- [ ] `Etmam/Gui/General/Masters/Disciplines/ucDisciplinesList.cs`
- [ ] `Etmam/Gui/General/Masters/Floors/frmFloorAddEdit.cs`
- [ ] `Etmam/Gui/General/Masters/Floors/ucFloorsList.cs`
- [ ] `Etmam/Gui/General/Masters/InspectionActivities/frmInspectionActivityAddEdit.cs`
- [ ] `Etmam/Gui/General/Masters/InspectionActivities/ucInspectionActivitiesList.cs`
- [ ] `Etmam/Gui/General/Masters/SecondaryDisciplines/frmSecondaryDisciplineAddEdit.cs`
- [ ] `Etmam/Gui/General/Masters/SecondaryDisciplines/ucSecondaryDisciplinesList.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsCategoryAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsCategorySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsIssuerAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsIssuerSelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsSubCategoryAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsSubCategorySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/ucDrawingsCategory.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/ucDrawingsIssuer.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/ucDrawingsSubCategory.cs`
- [ ] `Etmam/Gui/InventoryModule/Stores/frmStoreAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Stores/ucStores.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/frmSupplierAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/frmSupplierCategoryAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/ucSuppliers.cs`
- [ ] `Etmam/Gui/General/ImportFromExcel/ImportDataFromExcel.cs`
- [ ] `Etmam/Gui/General/ProjectsMgt/frmProjectSelect.cs`
- [x] `Etmam/Gui/General/ucAttachmentAddEdit.cs` (2026-08-24 — proved out the Attachments API; see
      above for what's live-verified vs. not)
- [ ] `Etmam/Gui/General/Setting/frmPermissionsAddEdit.cs`
- [ ] `Etmam/Gui/General/SystemSettings/SettingsForm.cs`
- [ ] `Etmam/Gui/General/UsersMgt/frmUsersMgt.cs` (touches the soft-delete-filter prerequisite —
      do after that lands)

### InventoryModule transactional documents (do 4th)

- [ ] `Etmam/Gui/InventoryModule/InventoryReports/ucInventoryReports.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/frmItemAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/frmItemCategoryAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/frmItemSelect.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/ucItems.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/ucItemsCategories.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/ucItemsList.cs`
- [ ] `Etmam/Gui/InventoryModule/OpeningBalance/OpeningBalancePrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/OpeningBalance/frmOpeningBalanceAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/OpeningBalance/ucOpeningBalance.cs`
- [ ] `Etmam/Gui/InventoryModule/Stocking/StockingPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/Stocking/frmStockingAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Stocking/ucStocking.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/MaterialIssuedPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/frmMaterialIssuedAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/frmMaterialIssuedLog.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/ucMaterialIssued.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/MaterialReceivePrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/frmMaterialReceiveAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/frmMaterialReceiveLog.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/frmPurchaseOrderSelect.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/ucMaterialReceive.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssueReturn/MaterialIssueReturnPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssueReturn/frmMaterialIssueReturnAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssueReturn/ucMaterialIssueReturn.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/MaterialTransferPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/frmMaterialTransferAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/frmMaterialTransferLog.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/ucMaterialTrasfare.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/PurchaseReturnPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/frmMaterialReceiveSelect.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/frmPurchaseReturnAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/ucPurchaseReturn.cs`

### ProcurementModule remaining documents (do 5th)

- [ ] `Etmam/Gui/ProcurementModule/Common/SimpleEditFormBase.cs` (base class — keep dual-purpose,
      supporting both `dc`-direct and API adapters, until every subclass has migrated)
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmPriceQuotationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmPriceQuotationCompareAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmPriceQuotationSelect.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmRFQAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmNegotiationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmAwardRecommendationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmTechnicalEvaluationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/ucPriceQuotation.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/ucPriceQuotationCompare.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/ucRFQ.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/PurchaseOrderPrinter.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/frmPOAmendmentAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/frmPurchaseRequestSelect.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/ucPOAmendment.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseRequest/PurchaseRequestPrinter.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseRequest/frmPurchaseRequestLog.cs`

### DocumentsMgt (do 6th — heaviest attachments consumer)

- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/CIRPrinter.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/CIRReissuer.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/frmCIRAction.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/frmBuildingSelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/frmDisciplineSelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/frmFloorSelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/frmInspectionActivitySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/frmSecondaryDisciplineSelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmDailyReport.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/DailyReportPrinter.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmActivityAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmActivitySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmEquipment.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmEquipmentAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmManpower.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmManpowerAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmWorkDoneAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmWorkDoneSelection.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmImportSchedule.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/frmDrawingsAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/ucDrawingsAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/ucDrawingsAttachment.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/ucDrawingsDahboard.cs`
- [ ] `Etmam/Gui/DocumentsMgt/MaterialApprovalRequest/frmMARAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/Transmittals/frmTransmittalAddEdit.cs`

### BOQMgt + WorkflowMgt (do 7th — smallest remaining, `ucMyWorkflowTasks.cs` needs the
### `GetPendingForUser` prerequisite)

- [ ] `Etmam/Gui/BOQMgt/BOQEditor/ucBOQEditor.cs`
- [ ] `Etmam/Gui/BOQMgt/BOQList/frmBOQNew.cs`
- [ ] `Etmam/Gui/BOQMgt/BOQList/ucBOQList.cs`
- [ ] `Etmam/Gui/WorkflowMgt/Definitions/frmApprovalMatrixAddEdit.cs`
- [ ] `Etmam/Gui/WorkflowMgt/Definitions/frmWorkflowDefinitionAddEdit.cs`
- [ ] `Etmam/Gui/WorkflowMgt/Definitions/ucApprovalMatrix.cs`
- [ ] `Etmam/Gui/WorkflowMgt/MyTasks/ucMyWorkflowTasks.cs`

### MainPage (small, no strong phase affinity)

- [ ] `Etmam/Gui/MainPage/frmMainPage.cs`
- [ ] `Etmam/Gui/MainPage/frmStart.cs`

### `Etmam/Code`/`Common` base classes and shared helpers (do last — referenced across every
### module above)

- [ ] `Etmam/Code/Base/BaseRibbonForm.cs`
- [ ] `Etmam/Code/Base/BaseUserControl.cs`
- [ ] `Etmam/Code/Helper/AttachmentStorage.cs` (likely collapses into the Attachments API
      prerequisite rather than being a standalone item — check when that lands)
- [ ] `Etmam/Code/Helper/PrintHelper.cs`
- [ ] `Etmam/Code/ProjectValidationHelper.cs`
- [ ] `Etmam/Gui/Common/frmSendEmail.cs`

### Not on this list — empty stubs, no migration needed

- `Etmam/Gui/BudgetMgt/BudgetImportWizard/frmBudgetImportWizard.cs` — all event handlers are no-ops
- `Etmam/Gui/PlanningMgt/ImportExportWizard/frmImportExportWizard.cs` — likewise tiny/stub

### Not on this list — whole modules with zero `DataContext.Shared` hits (unbuilt features or
### already data-free; confirm before assuming, don't just trust this note forever)

`BudgetMgt`, `ContractMgt`, `CorrespondenceMgt`, `CostControlMgt`, `EDMSMgt`, `HSEMgt`,
`PlanningMgt`, `QualityMgt`, `SubcontractorModule`, `ProjectsModule` (besides `ucProjectsList.cs`/
`frmProjectAddEdit.cs`/`ucProjectsMgt.cs`, already covered above/in "Known partially-migrated").
