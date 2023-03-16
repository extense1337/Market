using Market.Database;
using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.DomainRepositories.Repositories;
using Market.DomainServices.Interfaces;
using Market.DomainServices.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<MarketDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("NpgMarketDbConnection")));

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IProductService, ProductService>();

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