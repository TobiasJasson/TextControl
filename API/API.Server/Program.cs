using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --------------------------
// CONFIGURACIÓN DE SERVICIOS
// --------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TextControl API", Version = "v1" });
});

// Política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .AllowAnyOrigin()   // En Railway usaremos dominio público
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// --------------------------
// CONFIGURACIÓN DEL PIPELINE
// --------------------------

app.UseCors("AllowFrontend");

// Forzar HTTPS en Railway
app.UseHttpsRedirection();

// Habilitar archivos estáticos (React build)
app.UseDefaultFiles();
app.UseStaticFiles();

// Rutas API
app.MapControllers();

// Swagger sólo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Si no encuentra una ruta, devuelve el index.html de React
app.MapFallbackToFile("/index.html");

// Railway escucha en el puerto asignado automáticamente
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();