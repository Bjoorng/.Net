using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp;
using WebApp.Clients.TodoLists;
using WebApp.Clients.TodoItem;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//ToDo Lists Services

builder.Services.AddScoped(sp => new GetAllClient());
builder.Services.AddScoped(sp => new GetByIdClient());
builder.Services.AddScoped(sp => new CreateItemClient());

//Todo Items Service

builder.Services.AddScoped(sp => new GetItemByIdClient());
builder.Services.AddScoped(sp => new DeleteItemClient());
builder.Services.AddScoped(sp => new UpdateItemClient());
builder.Services.AddScoped(sp => new UpdateItemDoneClient());

await builder.Build().RunAsync();
