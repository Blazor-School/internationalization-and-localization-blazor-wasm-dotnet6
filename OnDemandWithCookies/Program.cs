using InstantTranslationWithCookies;
using InstantTranslationWithCookies.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => (IJSUnmarshalledRuntime)sp.GetRequiredService<IJSRuntime>());
builder.Services.AddScoped<BlazorSchoolCultureProvider>();
builder.Services.AddLocalization(options => options.ResourcesPath = "BlazorSchoolResources");

var wasmHost = builder.Build();
var culturesProvider = wasmHost.Services.GetService<BlazorSchoolCultureProvider>();

if (culturesProvider is not null)
{
    await culturesProvider.LoadCulturesAsync("fr", "en");
    await culturesProvider.SetStartupLanguageAsync("fr");
}

await wasmHost.RunAsync();