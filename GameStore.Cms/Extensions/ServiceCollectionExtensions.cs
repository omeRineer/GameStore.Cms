using Blazored.LocalStorage;
using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Enums;
using GameStore.Cms.Models.Rest.Blog;
using GameStore.Cms.Models.Rest.Category;
using GameStore.Cms.Models.Rest.Game;
using GameStore.Cms.Models.Rest.Identity.Permission;
using GameStore.Cms.Models.Rest.Identity.Profile;
using GameStore.Cms.Models.Rest.Identity.Role;
using GameStore.Cms.Models.Rest.Identity.User;
using GameStore.Cms.Models.Rest.Menu;
using GameStore.Cms.Models.Rest.SliderContent;
using GameStore.Cms.Providers;
using GameStore.Cms.Services.Handlers;
using GameStore.Cms.Services.Internal;
using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.Master.Identity;
using GameStore.Cms.Services.Meta;
using GameStore.Cms.Services.OData;
using GameStore.Cms.Services.OData.Identity;
using GameStore.Cms.Storages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GameStore.Cms.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<NotificationService>();

            services.AddScoped<CategoryService>();
            services.AddScoped<GameService>();
            services.AddScoped<MediaService>();
            services.AddScoped<SliderContentService>();
            services.AddScoped<MenuService>();
            services.AddScoped<BlogService>();
            services.AddScoped<AuthService>();
            services.AddScoped<ProfileService>();

            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<PermissionService>();
            services.AddScoped<UserRoleService>();
            services.AddScoped<UserPermisionService>();
            services.AddScoped<RolePermissionService>();

        }

        public static void AddAuthPolicies(this IServiceCollection services)
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
                opt.AddPolicy(Policies.Notification, policy => policy.Requirements.Add(new CustomAuthorizationRequirement("CMS.Components.Notification")));
            });
        }

        public static void AddStorages(this IServiceCollection services)
        {
            services.AddScoped<NotificationStorage>();
        }

        public static void AddUtilities(this IServiceCollection services)
        {
            services.AddScoped<HubConnectionProvider>();
            services.AddScoped<IAuthorizationHandler, CustomAuthorizationHandler>();
            services.AddScoped<AuthenticationStateProvider, CoreAuthenticationStateProvider>();
            services.AddScoped<CurrentUserService>();
            services.AddScoped<HttpClientService>();
            services.AddSingleton<MaterialconService>();
            services.AddBlazoredLocalStorageAsSingleton();
        }

        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.CreateMap<BlogModel, UpdateBlogModel>().ReverseMap();
                opt.CreateMap<CategoryModel, UpdateCategoryModel>().ReverseMap();
                opt.CreateMap<GameModel, UpdateGameModel>()
                            .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Category.Id))
                            .ReverseMap();
                opt.CreateMap<SliderContentModel, UpdateSliderContentModel>();
                opt.CreateMap<UserModel, UpdateUserModel>();
                opt.CreateMap<RoleModel, UpdateRoleModel>();
                opt.CreateMap<PermissionModel, UpdatePermissionModel>();
                opt.CreateMap<MenuModel, UpdateMenuModel>();
                opt.CreateMap<ProfileModel, UpdateProfileModel>();

                opt.AddGlobalIgnore("CreateDate");
                opt.AddGlobalIgnore("EditDate");
            });
        }

        public static void AddODataServices(this IServiceCollection services)
        {
            services.AddScoped<CategoryODataService>();
            services.AddScoped<GameODataService>();
            services.AddScoped<MediaODataService>();
            services.AddScoped<SliderContentODataService>();
            services.AddScoped<TypeLookupODataService>();
            services.AddScoped<MenuODataService>();
            services.AddScoped<BlogODataService>();

            services.AddScoped<UserODataService>();
            services.AddScoped<RoleODataService>();
            services.AddScoped<PermissionODataService>();
            services.AddScoped<UserRoleODataService>();
            services.AddScoped<UserPermissionODataService>();
            services.AddScoped<RolePermissionODataService>();
        }
    }
}
