using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Application.Dtos;
using Microsoft.AspNetCore.Components.Authorization;

namespace Web.Services;

/// <summary>
/// Web-project counterpart to the desktop client's Etmam/Code/Api/ApiClient.cs. Registered via
/// AddHttpClient&lt;EtmamApiClient&gt; (one instance per DI scope, BaseAddress = ApiBaseUrl config).
/// Must use JsonOptions (JsonSerializerDefaults.Web) on every call - the migration checklist
/// documents a real bug where omitting this silently deserialized every response to all-default
/// values because ASP.NET Core serializes camelCase and the default System.Text.Json options are
/// case-sensitive.
///
/// The bearer token is read straight from AuthenticationStateProvider (the "jwt" claim Program.cs's
/// /account/login endpoint put on the sign-in cookie) on every call rather than cached in a mutable
/// field: an earlier version cached it via a separate "run once per circuit" bootstrap component,
/// but that ran as a sibling of the page requesting data, so on first load the API call could race
/// ahead of the bootstrap and go out with no token (401). Asking the provider directly removes the
/// ordering dependency - it's already cheap/cached internally.
/// </summary>
public sealed class EtmamApiClient(HttpClient http, AuthenticationStateProvider authStateProvider)
{
    public static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    private async Task AttachTokenAsync()
    {
        var state = await authStateProvider.GetAuthenticationStateAsync();
        var token = state.User.FindFirst("jwt")?.Value;
        http.DefaultRequestHeaders.Authorization = token is { Length: > 0 }
            ? new AuthenticationHeaderValue("Bearer", token)
            : null;
    }

    // ── Generic CRUD helpers — every resource below is a thin, typed wrapper over these so the
    // per-entity methods stay short while every call still goes through AttachTokenAsync/JsonOptions. ──

    private async Task<List<T>> GetListAsync<T>(string url, CancellationToken ct)
    {
        await AttachTokenAsync();
        return await http.GetFromJsonAsync<List<T>>(url, JsonOptions, ct) ?? [];
    }

    private async Task<T?> GetByIdAsync<T>(string url, CancellationToken ct) where T : class
    {
        await AttachTokenAsync();
        var response = await http.GetAsync(url, ct);
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(JsonOptions, ct);
    }

    private async Task<int> CreateAsync<TRequest>(string url, TRequest request, CancellationToken ct)
    {
        await AttachTokenAsync();
        var response = await http.PostAsJsonAsync(url, request, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<int>(JsonOptions, ct);
    }

    private async Task UpdateAsync<TRequest>(string url, TRequest request, CancellationToken ct)
    {
        await AttachTokenAsync();
        var response = await http.PutAsJsonAsync(url, request, JsonOptions, ct);
        await EnsureSuccessAsync(response, ct);
    }

    private async Task DeleteAsync(string url, CancellationToken ct)
    {
        await AttachTokenAsync();
        var response = await http.DeleteAsync(url, ct);
        await EnsureSuccessAsync(response, ct);
    }

    /// <summary>POST with a request body and no return value - workflow actions (send/approve/
    /// reject/return-to-step), which all reply 204 No Content or a { message } error body.</summary>
    private async Task PostActionAsync<TRequest>(string url, TRequest request, CancellationToken ct)
    {
        await AttachTokenAsync();
        var response = await http.PostAsJsonAsync(url, request, JsonOptions, ct);
        await EnsureSuccessAsync(response, ct);
    }

    /// <summary>POST with no request body and no return value - close / return-for-edit.</summary>
    private async Task PostActionAsync(string url, CancellationToken ct)
    {
        await AttachTokenAsync();
        var response = await http.PostAsync(url, content: null, ct);
        await EnsureSuccessAsync(response, ct);
    }

    // Surfaces the Api's { message: "..." } BadRequest body (e.g. "لا يمكن حذف تصنيف رئيسي ثابت")
    // in the exception text instead of a bare "400 Bad Request", so dialogs can show it as-is.
    private static async Task EnsureSuccessAsync(HttpResponseMessage response, CancellationToken ct)
    {
        if (response.IsSuccessStatusCode)
            return;

        string? message = null;
        try
        {
            var body = await response.Content.ReadFromJsonAsync<JsonElement>(JsonOptions, ct);
            if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("message", out var m))
                message = m.GetString();
        }
        catch
        {
            // response body wasn't the expected { message } shape - fall through to the generic error
        }

        throw new HttpRequestException(message ?? $"{(int)response.StatusCode} {response.ReasonPhrase}");
    }

    // ── Auth ──

    public async Task<LoginResponse?> LoginAsync(string userName, string password, CancellationToken ct = default)
    {
        var response = await http.PostAsJsonAsync(
            "api/auth/login",
            new LoginRequest { UserName = userName, Password = password },
            JsonOptions,
            ct);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<LoginResponse>(JsonOptions, ct);
    }

    // ── Projects ──

    public Task<List<ProjectDto>> GetProjectsAsync(CancellationToken ct = default) =>
        GetListAsync<ProjectDto>("api/projects", ct);

    public Task<ProjectDto?> GetProjectAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<ProjectDto>($"api/projects/{id}", ct);

    public Task<int> CreateProjectAsync(ProjectCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/projects", request, ct);

    public Task UpdateProjectAsync(int id, ProjectUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/projects/{id}", request, ct);

    public Task DeleteProjectAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/projects/{id}", ct);

    public Task<List<StakeholderLookupDto>> GetProjectClientsAsync(CancellationToken ct = default) =>
        GetListAsync<StakeholderLookupDto>("api/projects/clients", ct);

    public Task<List<StakeholderLookupDto>> GetProjectConsultantsAsync(CancellationToken ct = default) =>
        GetListAsync<StakeholderLookupDto>("api/projects/consultants", ct);

    // ── Suppliers (StakeholdersList, IsVendor = true) ──

    public Task<List<SupplierDto>> GetSuppliersAsync(CancellationToken ct = default) =>
        GetListAsync<SupplierDto>("api/suppliers", ct);

    public Task<List<SupplierCategoryDto>> GetSupplierCategoriesAsync(CancellationToken ct = default) =>
        GetListAsync<SupplierCategoryDto>("api/suppliers/categories", ct);

    public Task<SupplierDto?> GetSupplierAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<SupplierDto>($"api/suppliers/{id}", ct);

    public Task<int> CreateSupplierAsync(SupplierCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/suppliers", request, ct);

    public Task UpdateSupplierAsync(int id, SupplierUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/suppliers/{id}", request, ct);

    public Task DeleteSupplierAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/suppliers/{id}", ct);

    // ── Item categories ──

    public Task<List<ItemCategoryDto>> GetItemCategoriesAsync(CancellationToken ct = default) =>
        GetListAsync<ItemCategoryDto>("api/item-categories", ct);

    public Task<ItemCategoryDto?> GetItemCategoryAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<ItemCategoryDto>($"api/item-categories/{id}", ct);

    public Task<int> CreateItemCategoryAsync(ItemCategoryCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/item-categories", request, ct);

    public Task UpdateItemCategoryAsync(int id, ItemCategoryUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/item-categories/{id}", request, ct);

    public Task DeleteItemCategoryAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/item-categories/{id}", ct);

    // ── Units ──

    public Task<List<UnitDto>> GetUnitsAsync(CancellationToken ct = default) =>
        GetListAsync<UnitDto>("api/units", ct);

    public Task<UnitDto?> GetUnitAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<UnitDto>($"api/units/{id}", ct);

    public Task<int> CreateUnitAsync(UnitCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/units", request, ct);

    public Task UpdateUnitAsync(int id, UnitUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/units/{id}", request, ct);

    public Task DeleteUnitAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/units/{id}", ct);

    // ── Items ──

    public Task<List<ItemDto>> GetItemsAsync(CancellationToken ct = default) =>
        GetListAsync<ItemDto>("api/items", ct);

    public Task<ItemDto?> GetItemAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<ItemDto>($"api/items/{id}", ct);

    public Task<int> CreateItemAsync(ItemCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/items", request, ct);

    public Task UpdateItemAsync(int id, ItemUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/items/{id}", request, ct);

    public Task DeleteItemAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/items/{id}", ct);

    // ── Stores ──

    public Task<List<StoreDto>> GetStoresAsync(CancellationToken ct = default) =>
        GetListAsync<StoreDto>("api/stores", ct);

    public Task<StoreDto?> GetStoreAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<StoreDto>($"api/stores/{id}", ct);

    public Task<int> CreateStoreAsync(StoreCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/stores", request, ct);

    public Task UpdateStoreAsync(int id, StoreUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/stores/{id}", request, ct);

    public Task DeleteStoreAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/stores/{id}", ct);

    // ── Purchase Requests ──

    public Task<List<PurchaseRequestDto>> GetPurchaseRequestsAsync(CancellationToken ct = default) =>
        GetListAsync<PurchaseRequestDto>("api/purchase-requests", ct);

    public Task<PurchaseRequestDto?> GetPurchaseRequestAsync(int id, CancellationToken ct = default) =>
        GetByIdAsync<PurchaseRequestDto>($"api/purchase-requests/{id}", ct);

    public Task<int> CreatePurchaseRequestAsync(PurchaseRequestCreateRequest request, CancellationToken ct = default) =>
        CreateAsync("api/purchase-requests", request, ct);

    public Task UpdatePurchaseRequestAsync(int id, PurchaseRequestUpdateRequest request, CancellationToken ct = default) =>
        UpdateAsync($"api/purchase-requests/{id}", request, ct);

    public Task DeletePurchaseRequestAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"api/purchase-requests/{id}", ct);

    public Task<List<WorkflowDefinitionDto>> GetAvailableProceduresAsync(int id, CancellationToken ct = default) =>
        GetListAsync<WorkflowDefinitionDto>($"api/purchase-requests/{id}/available-procedures", ct);

    public Task SendPurchaseRequestForApprovalAsync(int id, int workflowDefinitionId, CancellationToken ct = default) =>
        PostActionAsync($"api/purchase-requests/{id}/send", new SendForApprovalRequest { WorkflowDefinitionId = workflowDefinitionId }, ct);

    public Task ApprovePurchaseRequestAsync(int id, string? comment, CancellationToken ct = default) =>
        PostActionAsync($"api/purchase-requests/{id}/approve", new WorkflowActionRequest { Comment = comment }, ct);

    public Task RejectPurchaseRequestAsync(int id, string? comment, CancellationToken ct = default) =>
        PostActionAsync($"api/purchase-requests/{id}/reject", new WorkflowActionRequest { Comment = comment }, ct);

    public Task<List<WorkflowStepOptionDto>> GetReturnToStepOptionsAsync(int id, CancellationToken ct = default) =>
        GetListAsync<WorkflowStepOptionDto>($"api/purchase-requests/{id}/return-to-step-options", ct);

    public Task ReturnPurchaseRequestToStepAsync(int id, int targetStepOrder, string comment, CancellationToken ct = default) =>
        PostActionAsync($"api/purchase-requests/{id}/return-to-step", new ReturnToStepRequest { TargetStepOrder = targetStepOrder, Comment = comment }, ct);

    public Task ClosePurchaseRequestAsync(int id, CancellationToken ct = default) =>
        PostActionAsync($"api/purchase-requests/{id}/close", ct);

    public Task ReturnPurchaseRequestForEditAsync(int id, CancellationToken ct = default) =>
        PostActionAsync($"api/purchase-requests/{id}/return-for-edit", ct);

    // ── Procurement lookups (read-only) ──

    public Task<List<CostCenterLookupDto>> GetCostCentersAsync(CancellationToken ct = default) =>
        GetListAsync<CostCenterLookupDto>("api/lookups/cost-centers", ct);

    public Task<List<BudgetLookupDto>> GetBudgetsAsync(CancellationToken ct = default) =>
        GetListAsync<BudgetLookupDto>("api/lookups/budgets", ct);

    public Task<List<DisciplineLookupDto>> GetDisciplinesAsync(CancellationToken ct = default) =>
        GetListAsync<DisciplineLookupDto>("api/lookups/disciplines", ct);

    public Task<List<DepartmentLookupDto>> GetDepartmentsAsync(CancellationToken ct = default) =>
        GetListAsync<DepartmentLookupDto>("api/lookups/departments", ct);
}
