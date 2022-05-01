using Transactions.Application;
using Transactions.Persistence;
using Transactions.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Add Application services
builder.Services.AddApplicationExtensions();

builder.Services.AddPersistenceExtensions(builder.Configuration);

builder.Services.AddSharedInfraestructureExtensions();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
