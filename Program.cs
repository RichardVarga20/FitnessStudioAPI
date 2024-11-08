using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FitnessStudioAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adatb�zis kapcsolat be�ll�t�sa (SQLite)
builder.Services.AddDbContext<FitnessStudioContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Szolg�ltat�sok regisztr�l�sa
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // NewtonSoftJson haszn�lata az JSON konvert�l�shoz

// Swagger be�ll�t�s (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitness Studio API", Version = "v1" });
});

var app = builder.Build();

// Swagger UI el�rhet�s�g
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitness Studio API v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
