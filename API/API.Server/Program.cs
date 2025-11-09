var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVite",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowVite");

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Sirve los archivos del frontend (Vite)
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Si no encuentra una ruta de la API, sirve el index.html (Vite SPA)
app.MapFallbackToFile("/index.html");

app.Run();