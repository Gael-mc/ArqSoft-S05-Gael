using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Repositories
{
    public class JsonPacienteRepository : IPacienteRepository
    {
        private readonly IJsonFileStore _store;

        public JsonPacienteRepository(IJsonFileStore store) => _store = store;

        public List<Paciente> ObtenerTodos() => _store.Leer<Paciente>("pacientes.json");

        public Paciente? ObtenerPorId(int id) =>
            ObtenerTodos().FirstOrDefault(p => p.Id == id);
    }
}