using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly IJsonFileStore _store;

        public JsonCitaRepository(IJsonFileStore store) => _store = store;

        public List<Cita> ObtenerTodos() =>
            _store.Leer<CitaJson>("citas.json").Select(MapearCita).ToList();

        public List<Cita> ObtenerPorPaciente(int pacienteId) =>
            ObtenerTodos().Where(c => c.PacienteId == pacienteId).ToList();

        private static Cita MapearCita(CitaJson c) => new()
        {
            Id = c.Id,
            PacienteId = c.PacienteId,
            MedicoId = c.MedicoId,
            Fecha = DateOnly.Parse(c.Fecha),
            Hora = TimeOnly.Parse(c.Hora),
            Motivo = c.Motivo,
            Estado = c.Estado
        };
    }

    internal class CitaJson
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
        public string Motivo { get; set; } = string.Empty;
    }
}