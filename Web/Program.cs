using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MudBlazor.Services;
using Web.Components;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });
// Every page requires sign-in by default; pages that must stay reachable while anonymous
// (Login, NotFound, Error) opt out individually with [AllowAnonymous]. Static assets and the
// login/logout endpoints below opt out too - without that, the fallback policy 302s CSS/JS/
// _content requests to /login as well, which breaks script loading for anonymous visitors.
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddMudServices();

builder.Services.AddHttpClient<EtmamApiClient>(client =>
{
    // Blazor Server: this HttpClient call goes server-to-server from the Web process to the Api
    // process, never through the browser - so Api needs no CORS configuration for this to work.
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"]
        ?? throw new InvalidOperationException("Missing configuration value 'ApiBaseUrl'.");
    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// Plain (non-Blazor) endpoints for sign-in/out: writing the auth cookie requires a normal HTTP
// response, which an already-established interactive Blazor circuit can't do - this is why
// Login.razor stays a static SSR page whose <form> posts here instead of calling SignInAsync
// from a Blazor event handler.
app.MapPost("/account/login", async (HttpContext http, EtmamApiClient api) =>
{
    var form = await http.Request.ReadFormAsync();
    var userName = form["username"].ToString();
    var password = form["password"].ToString();
    var returnUrl = form["returnUrl"].ToString();

    var result = await api.LoginAsync(userName, password);
    if (result is null)
    {
        var target = string.IsNullOrEmpty(returnUrl) ? "/login" : $"/login?returnUrl={Uri.EscapeDataString(returnUrl)}";
        return Results.Redirect($"{target}{(target.Contains('?') ? "&" : "?")}error=1");
    }

    var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, result.UserId.ToString()),
        new(ClaimTypes.Name, result.UserName),
        new(ClaimTypes.Role, result.Role ?? ""),
        new("full_name", result.FullName ?? result.UserName),
        new("jwt", result.Token),
        new("jwt_exp", result.ExpiresAtUtc.ToString("O")),
        new("must_change_password", result.MustChangePassword ? "1" : "0"),
    };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
    {
        IsPersistent = false,
        ExpiresUtc = result.ExpiresAtUtc,
    });

    return Results.Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
}).AllowAnonymous();

app.MapPost("/account/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
}).AllowAnonymous();

app.MapStaticAssets().AllowAnonymous();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
