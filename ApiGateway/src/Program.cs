using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Adding Ocelot service  
builder.Services.AddOcelot(); //inyectando dependencia  del using 


//Adding the Logging   //  para  hace debuggeo  
builder.Host.ConfigureLogging((hostingContext, logginBuilder) =>
{
    logginBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logginBuilder.AddConsole();
    logginBuilder.AddDebug();
});

builder.Host.ConfigureAppConfiguration((hosting, config) =>
{
    config.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
});

var app = builder.Build();

app.UseOcelot().Wait();
//app.MapGet("/", () => "Hello World!");

app.Run();
