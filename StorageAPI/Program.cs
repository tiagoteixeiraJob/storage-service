using StorageAPI.Models;
using StorageAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Services
builder.Services.AddScoped<IStorageService, StorageService>();

// AppSetings
IConfiguration configuration = builder.Configuration;
builder.Services.Configure<AppParameters>(configuration.GetSection("AppParameters"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();