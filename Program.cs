using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FitnessStudioAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adatbázis kapcsolat beállítása (SQLite)
builder.Services.AddDbContext<FitnessStudioContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Szolgáltatások regisztrálása
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // NewtonSoftJson használata az JSON konvertáláshoz

// Swagger beállítás (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitness Studio API", Version = "v1" });
});

var app = builder.Build();

// Swagger UI elérhetõség
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitness Studio API v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
