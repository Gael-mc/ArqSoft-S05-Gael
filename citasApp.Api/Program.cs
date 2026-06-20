using CitasApp.Application.Services;
using CitasApp.Domain.Interfaces;
using CitasApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar CORS para permitir que tu HTML se comunique con la API
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirTodo", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddControllers();

// Repositorios
builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();

// Servicios
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();

var app = builder.Build();

// 2. Activar los servicios configurados
app.UseHttpsRedirection();
app.UseCors("PermitirTodo"); // <--- Habilitar CORS
// app.UseStaticFiles();        <--- ESTA LÍNEA ES LA QUE DABA EL ERROR. ESTÁ COMENTADA.
app.UseAuthorization();
app.MapControllers();

app.Run();