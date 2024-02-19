using Blazored.LocalStorage;
using Fluxor;
using ImgPOC;
using MatBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluxor(option =>
{
    option.ScanAssemblies(typeof(Program).Assembly);
    option.UseReduxDevTools(rdt => { rdt.Name = "POC"; });
});

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddMatBlazor();
builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.TopCenter;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 2000;
});
builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.WriteIndented = true;
});

await builder.Build().RunAsync();
