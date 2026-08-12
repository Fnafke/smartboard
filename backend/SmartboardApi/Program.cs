using Microsoft.EntityFrameworkCore;
using SmartboardApi.Data;
using SmartboardApi.Repositories.UserRepository;
using SmartboardApi.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SmartboardDBContext") ?? throw new InvalidOperationException("Connection string 'SmartboardDBContext' not found.");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddDbContext<SmartboardDBContext>(options => options.UseInMemoryDatabase("SmartboardDB"));
builder.Services.AddDbContext<SmartboardDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
