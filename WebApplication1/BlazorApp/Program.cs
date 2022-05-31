using BlazorApp;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7217") });
builder.Services.AddScoped<IProductProvider, ProductProvider>();
builder.Services.AddScoped<ICustomerProvider, CustomerProvider>();
builder.Services.AddScoped<IDeliveryProvider, DeliveryProvider>();
builder.Services.AddScoped<IShipmentProvider, ShipmentProvider>();
await builder.Build().RunAsync();
