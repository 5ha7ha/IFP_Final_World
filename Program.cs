using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TravelTheWorld;
using TravelTheWorld.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Weather: talks directly to the free Open-Meteo API (same source as the original weather.js).
builder.Services.AddScoped<IWeatherService>(_ =>
    new OpenMeteoWeatherService(new HttpClient { BaseAddress = new Uri("https://api.open-meteo.com/") }));

builder.Services.AddSingleton<GameState>();

// Search: in-memory for now. Swap for a JSON/HTTP-backed implementation once data.js is ported.
builder.Services.AddSingleton<ICountryRepository, InMemoryCountryRepository>();
builder.Services.AddSingleton<ISearchService, SearchService>();

await builder.Build().RunAsync();
