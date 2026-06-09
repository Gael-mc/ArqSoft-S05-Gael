using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace CitasApp.Infrastructure.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonCitaRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "citas.json");
        }

        public List<Cita> ObtenerTodos()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            var citasJson = JsonSerializer.Deserialize<List<CitaJson>>(json, _options) ?? new();
            return citasJson.Select(c => new Cita
            {
                Id = c.Id,
                PacienteId = c.PacienteId,
                MedicoId = c.MedicoId,
                Fecha = DateOnly.Parse(c.Fecha),
                Hora = TimeOnly.Parse(c.Hora),
                Motivo = c.Motivo,
                Estado = c.Estado
            }).ToList();
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId) =>
            ObtenerTodos().Where(c => c.PacienteId == pacienteId).ToList();
    }

    internal class CitaJson
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
    }
}