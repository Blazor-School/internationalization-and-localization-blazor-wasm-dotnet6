using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace OnDemandWithCookies.Utils;

public class BlazorSchoolRequestCultureProvider : RequestCultureProvider
{
    public string DefaultCulture { get; set; }

    public BlazorSchoolRequestCultureProvider(string defaultCulture)
    {
        DefaultCulture = defaultCulture;
    }

    public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    {
        Console.WriteLine("here");
        string inputCulture = httpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        var result = CookieRequestCultureProvider.ParseCookieValue(inputCulture);

        if (result is null)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(DefaultCulture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(DefaultCulture);
            result = new(DefaultCulture);
        }
        else
        {
            string storedLanguage = result.Cultures.First().Value;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(storedLanguage);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(storedLanguage);
        }

        return Task.FromResult(result);
    }
}