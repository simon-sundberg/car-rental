using Car_Rental.App;
using Car_Rental.Business.Classes;
using Car_Rental.Common.Error;
using Car_Rental.Data.Classes;
using Car_Rental.Data.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
);
builder.Services.AddSingleton<IData, CollectionData>();
builder.Services.AddSingleton<BookingProcessor>();
builder.Services.AddSingleton<ErrorTracker>();

await builder.Build().RunAsync();
