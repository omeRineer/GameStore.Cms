using Blazored.LocalStorage;
using GameStore.Cms.Models.Enums;
using GameStore.Cms.Models.Identity;
using GameStore.Cms.Providers;
using GameStore.Cms.Services.Handlers;
using GameStore.Cms.Services.Internal;
using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.Master.Identity;
using GameStore.Cms.Services.OData;
using GameStore.Cms.Services.OData.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GameStore.Cms.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAuthorizationCore(opt =>
            {
                opt.AddPolicy(Policies.Blog, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("Blogger,CMS.Components.Blog")));
                opt.AddPolicy(Policies.Game, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.Game")));
                opt.AddPolicy(Policies.Category, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.Category")));
                opt.AddPolicy(Policies.Identity, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.Identity")));
                opt.AddPolicy(Policies.SliderContent, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.SliderContent")));
                opt.AddPolicy(Policies.Lookup, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.Lookup")));
                opt.AddPolicy(Policies.Menu, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.Menu")));
            });
            services.AddScoped<IAuthorizationHandler, CustomAuthorizationHandler>();
            services.AddScoped<AuthenticationStateProvider, CoreAuthenticationStateProvider>();
            services.AddScoped<CurrentUserService>();
            services.AddScoped<HttpClientService>();
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
