using GameStore.Cms;
using GameStore.Cms.Extensions;
using GameStore.Cms.Providers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await CmsConfiguration.InitializeAsync(builder.HostEnvironment.Environment, new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddServices();
builder.Services.AddAuthPolicies();
builder.Services.AddStorages();
builder.Services.AddUtilities();
builder.Services.AddODataServices();
builder.Services.AddMappers();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRadzenComponents();

var host = builder.Build();

StaticServiceProvider.CreateInstance(host.Services.GetService<IServiceScopeFactory>());

await host.RunAsync();