using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using OnDemandWithCookies;
using OnDemandWithCookies.Utils;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(typeof(IStringLocalizer<>), typeof(BlazorSchoolStringLocalizer<>));
builder.Services.AddLocalization(options => options.ResourcesPath = "BlazorSchoolResources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.RequestCultureProviders = new List<IRequestCultureProvider>()
    {
        new BlazorSchoolRequestCultureProvider("fr")
    };
});

var map = builder.RootComponents;
foreach(var t in map)
{
    
}

await builder.Build().RunAsync();