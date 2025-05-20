using Blazored.LocalStorage;
using GameStore.Cms.Models.Identity;
using GameStore.Cms.Providers;
using GameStore.Cms.Services.Internal;
using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.Master.Identity;
using GameStore.Cms.Services.OData;
using GameStore.Cms.Services.OData.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GameStore.Cms.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, CoreAuthenticationStateProvider>();
            services.AddScoped<CurrentUserService>();
            services.AddBlazoredLocalStorageAsSingleton();

            services.AddSingleton<CategoryService>();
            services.AddSingleton<GameService>();
            services.AddSingleton<MediaService>();
            services.AddSingleton<SliderContentService>();
            services.AddSingleton<MenuService>();
            services.AddSingleton<BlogService>();
            services.AddSingleton<AuthService>();

            services.AddSingleton<UserService>();
            services.AddSingleton<RoleService>();
            services.AddSingleton<PermissionService>();
            services.AddSingleton<UserRoleService>();
            services.AddSingleton<UserPermisionService>();
            services.AddSingleton<RolePermissionService>();

        }

        public static void AddODataServices(this IServiceCollection services)
        {
            services.AddSingleton<CategoryODataService>();
            services.AddSingleton<GameODataService>();
            services.AddSingleton<MediaODataService>();
            services.AddSingleton<SliderContentODataService>();
            services.AddSingleton<TypeLookupODataService>();
            services.AddSingleton<MenuODataService>();
            services.AddSingleton<BlogODataService>();

            services.AddSingleton<UserODataService>();
            services.AddSingleton<RoleODataService>();
            services.AddSingleton<PermissionODataService>();
            services.AddSingleton<UserRoleODataService>();
            services.AddSingleton<UserPermissionODataService>();
            services.AddSingleton<RolePermissionODataService>();
        }
    }
}
