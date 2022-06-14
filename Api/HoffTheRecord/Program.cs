using API;
using API.UniversalExceptionHandler.DomainExceptionHandler;
using API.UniversalExceptionHandler.ValidationExceptionHandler;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddImplemenationDependencies();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateSchema();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomValidationExceptionMiddleware();
app.UseCustomDomainExceptionMiddleware();

app.MapControllers();

app.Run();


public partial class Program { }