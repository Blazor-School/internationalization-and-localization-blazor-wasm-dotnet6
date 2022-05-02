using InstantTranslationWithLocalStorage;
using InstantTranslationWithLocalStorage.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("InternalHttpClient", httpClient => httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped(typeof(IStringLocalizer<>), typeof(BlazorSchoolStringLocalizer<>));
builder.Services.AddScoped<BlazorSchoolCultureProvider>();
builder.Services.AddScoped<BlazorSchoolResourceMemoryStorage>();
builder.Services.AddLocalization(options => options.ResourcesPath = "lang");

var wasmHost = builder.Build();
var culturesProvider = wasmHost.Services.GetService<BlazorSchoolCultureProvider>();

if (culturesProvider is not null)
{
    await culturesProvider.SetStartupLanguageAsync("fr");
}

await wasmHost.RunAsync();
