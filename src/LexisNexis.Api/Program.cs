using LexisNexis.Api.Middleware;
using LexisNexis.Infrastructure;
using LexisNexis.Application;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

// Add custom LexisNexis services
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorLoggingMiddleware>();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
