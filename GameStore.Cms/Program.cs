using Core.Utilities.ServiceTools;
using GameStore.Cms;
using GameStore.Cms.Extensions;
using GameStore.Cms.Models.Blog;
using GameStore.Cms.Models.Category;
using GameStore.Cms.Models.Game;
using GameStore.Cms.Models.SliderContent;
using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.OData;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await CmsConfiguration.InitializeAsync(builder.HostEnvironment.Environment, new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddServices();
builder.Services.AddODataServices();
builder.Services.AddAutoMapper(opt =>
{
    opt.CreateMap<SingleBlogModel, UpdateBlogModel>().ReverseMap();
    opt.CreateMap<SingleCategoryModel, UpdateCategoryModel>().ReverseMap();
    opt.CreateMap<SingleGameModel, UpdateGameModel>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Category.Id))
                .ReverseMap();
    opt.CreateMap<SingleSliderContentModel, UpdateSliderContentModel>();


    opt.AddGlobalIgnore("CreateDate");
    opt.AddGlobalIgnore("EditDate");
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRadzenComponents();

var host = builder.Build();

StaticServiceProvider.CreateInstance(host.Services.GetService<IServiceScopeFactory>());

await host.RunAsync();