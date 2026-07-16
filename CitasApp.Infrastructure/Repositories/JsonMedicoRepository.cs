using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Repositories
{
    public class JsonMedicoRepository : IMedicoRepository
    {
        private readonly IJsonFileStore _store;

        public JsonMedicoRepository(IJsonFileStore store) => _store = store;

        public List<Medico> ObtenerTodos() => _store.Leer<Medico>("medicos.json");

        public Medico? ObtenerPorId(int id) =>
            ObtenerTodos().FirstOrDefault(m => m.Id == id);
    }
}