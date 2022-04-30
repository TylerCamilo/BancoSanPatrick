using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Adding Ocelot service  
builder.Services.AddOcelot(); //inyectando dependencia  del using 

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("giugigiugiugiugiuigiguiugiugiui6r67677er67ee76e76e")),
            ClockSkew = new System.TimeSpan(0)
        };
    });

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

app.UseCors("corsapp");
app.UseAuthentication();
app.UseOcelot().Wait();
//app.MapGet("/", () => "Hello World!");

app.Run();
