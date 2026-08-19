using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWorkflowEntityDescriber, PurchaseRequestEntityDescriber>();
            services.AddScoped<IWorkflowEntityDescriber, PurchaseOrderEntityDescriber>();
            services.AddScoped<IWorkflowEntityDescriber, ConstructionInspectionRequestEntityDescriber>();
            services.AddScoped<AuthService>();
            services.AddScoped<ProjectsService>();
            services.AddScoped<SuppliersService>();
            services.AddScoped<ItemCategoriesService>();
            services.AddScoped<UnitsService>();
            services.AddScoped<ItemsService>();
            services.AddScoped<StoresService>();
            services.AddScoped<ProjectAccessService>();
            services.AddScoped<PurchaseRequestsService>();
            services.AddScoped<PurchaseOrdersService>();
            services.AddScoped<ConstructionInspectionRequestsService>();
            services.AddScoped<ProcurementLookupsService>();

            return services;
        }
    }
}
