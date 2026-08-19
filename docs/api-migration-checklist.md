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
"DataContext.Shared" Etmam --include="*.cs"` right after the Auth + Projects vertical slice
landed — 103 files remained at that point, grouped below by `Etmam/Gui/*` module.

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

## Remaining files by module

### Code (base/shared)

- [ ] `Etmam/Code/Base/BaseRibbonForm.cs`
- [ ] `Etmam/Code/Base/BaseUserControl.cs`
- [ ] `Etmam/Code/Helper/PrintHelper.cs`

### DocumentsMgt

- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/DailyReportPrinter.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmActivityAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmActivitySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmDailyReport.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmEquipment.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmEquipmentAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmImportSchedule.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmManpower.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmManpowerAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmWorkDoneAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DailyReport/frmWorkDoneSelection.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsCategoryAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsCategorySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsIssuerAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsIssuerSelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsSubCategoryAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/frmDrawingsSubCategorySelect.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/ucDrawingsCategory.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/ucDrawingsIssuer.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/Masters/ucDrawingsSubCategory.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/frmDrawingsAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/ucDrawingsAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/ucDrawingsAttachment.cs`
- [ ] `Etmam/Gui/DocumentsMgt/DrawingsMgt/ucDrawingsDahboard.cs`
- [ ] `Etmam/Gui/DocumentsMgt/MaterialApprovalRequest/frmMARAddEdit.cs`
- [ ] `Etmam/Gui/DocumentsMgt/Transmittals/frmTransmittalAddEdit.cs`

### General

- [ ] `Etmam/Gui/General/ImportFromExcel/ImportDataFromExcel.cs`
- [ ] `Etmam/Gui/General/Masters/Disciplines/frmDisciplineAddEdit.cs`
- [ ] `Etmam/Gui/General/Masters/Disciplines/ucDisciplinesList.cs`
- [ ] `Etmam/Gui/General/ProjectsMgt/frmProjectSelect.cs`
- [ ] `Etmam/Gui/General/Setting/frmPermissionsAddEdit.cs`
- [ ] `Etmam/Gui/General/SystemSettings/SettingsForm.cs`
- [ ] `Etmam/Gui/General/UsersMgt/frmUsersMgt.cs`
- [ ] `Etmam/Gui/General/ucAttachmentAddEdit.cs`

### InventoryModule

- [ ] `Etmam/Gui/InventoryModule/InventoryReports/ucInventoryReports.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/frmItemAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/frmItemCategoryAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/frmItemSelect.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/ucItems.cs`
- [ ] `Etmam/Gui/InventoryModule/Items/ucItemsCategories.cs`
- [ ] `Etmam/Gui/InventoryModule/Masters/frmUnitAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Masters/ucUnits.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssueReturn/MaterialIssueReturnPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssueReturn/frmMaterialIssueReturnAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssueReturn/ucMaterialIssueReturn.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/MaterialIssuedPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/frmMaterialIssuedAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialIssued/ucMaterialIssued.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/MaterialReceivePrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/frmMaterialReceiveAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/frmPurchaseOrderSelect.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialReceive/ucMaterialReceive.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/MaterialTransferPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/frmMaterialTransferAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/MaterialTransfer/ucMaterialTrasfare.cs`
- [ ] `Etmam/Gui/InventoryModule/OpeningBalance/OpeningBalancePrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/OpeningBalance/frmOpeningBalanceAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/OpeningBalance/ucOpeningBalance.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/PurchaseReturnPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/frmMaterialReceiveSelect.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/frmPurchaseReturnAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/PurchaseReturn/ucPurchaseReturn.cs`
- [ ] `Etmam/Gui/InventoryModule/Stocking/StockingPrinter.cs`
- [ ] `Etmam/Gui/InventoryModule/Stocking/frmStockingAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Stocking/ucStocking.cs`
- [ ] `Etmam/Gui/InventoryModule/Stores/frmStoreAddEdit.cs`
- [ ] `Etmam/Gui/InventoryModule/Stores/ucStores.cs`

### MainPage

- [ ] `Etmam/Gui/MainPage/frmMainPage.cs`
- [ ] `Etmam/Gui/MainPage/frmUpdatePassword.cs`

### ProcurementModule

- [ ] `Etmam/Gui/ProcurementModule/Common/SimpleEditFormBase.cs` (base class — other subclasses
      besides `frmProjectAddEdit` still use `dc` directly; keep it dual-purpose until every
      subclass has its own `IDataHelper<T>` API adapter)
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmAwardRecommendationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmNegotiationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmPriceQuotationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmPriceQuotationCompareAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmPriceQuotationSelect.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmRFQAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/frmTechnicalEvaluationAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/ucPriceQuotation.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/ucPriceQuotationCompare.cs`
- [ ] `Etmam/Gui/ProcurementModule/PriceQuotation/ucRFQ.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/frmPOAmendmentAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/frmPurchaseOrderAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/frmPurchaseRequestSelect.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/ucPOAmendment.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseOrder/ucPurchaseOrder.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseRequest/PurchaseRequestPrinter.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseRequest/frmPurchaseRequestAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseRequest/frmPurchaseRequestLog.cs`
- [ ] `Etmam/Gui/ProcurementModule/PurchaseRequest/ucPurchaseRequests.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/frmSupplierAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/frmSupplierCategoryAddEdit.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/frmSupplierSelect.cs`
- [ ] `Etmam/Gui/ProcurementModule/Suppliers/ucSuppliers.cs`

### WorkflowMgt

- [ ] `Etmam/Gui/WorkflowMgt/Definitions/frmApprovalMatrixAddEdit.cs`
- [ ] `Etmam/Gui/WorkflowMgt/Definitions/frmWorkflowDefinitionAddEdit.cs`
- [ ] `Etmam/Gui/WorkflowMgt/Definitions/ucApprovalMatrix.cs`
- [ ] `Etmam/Gui/WorkflowMgt/MyTasks/ucMyWorkflowTasks.cs`
