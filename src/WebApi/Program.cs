using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Application.Distances.Calculators;
using Application.Distances.Converters;
using Application.Distances.Queries;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

services.AddSingleton<IDistanceCalculatorFactory, DistanceCalculatorFactory>();
services.AddSingleton<IDistanceUnitConverterFactory, DistanceUnitConverterFactory>();
services.AddSingleton<IRequestHandler<GetDistanceQuery, double>, GetDistanceQueryHandler>();

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

[ExcludeFromCodeCoverage]
public abstract partial class Program
{
}