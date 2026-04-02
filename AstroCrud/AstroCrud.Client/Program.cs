using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AstroCrud.Client;
using AstroCrud.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Cambia este puerto por el puerto real de tu API cuando la ejecutes
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7043/")
});

builder.Services.AddScoped<ObservacionApiService>();

await builder.Build().RunAsync();