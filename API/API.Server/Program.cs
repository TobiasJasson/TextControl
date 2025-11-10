var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowReact");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Esto sirve los archivos del frontend compilado
app.UseDefaultFiles();  // Busca index.html automáticamente
app.UseStaticFiles();   // Sirve el contenido de wwwroot

app.MapControllers();

// ✅ Si no encuentra una ruta en la API, devuelve el index.html de React
app.MapFallbackToFile("/index.html");

app.Run();
