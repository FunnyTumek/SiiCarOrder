using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using FactoryPortal;
using FactoryPortal.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<IProductionsService, ProductionsService>();

builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri(@"http://localhost:8083/") 
    });

builder.Services.AddSingleton<HubConnection>(sp => {
	var navigationManager = sp.GetRequiredService<NavigationManager>();
	return new HubConnectionBuilder()
	  .WithUrl(navigationManager.ToAbsoluteUri("http://localhost:8083/productionProgressNotifications"))
	  .WithAutomaticReconnect()
	  .Build();
});

builder.Services.AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
