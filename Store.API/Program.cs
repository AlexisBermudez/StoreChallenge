using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.API.Context;
using Store.API.Profiles;
using Store.API.Repository;
using Store.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreChallenge"));
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddAutoMapper(typeof(StoreProfile));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
