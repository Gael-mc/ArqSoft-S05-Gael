using CitasApp.Domain.Interfaces;

namespace CitasApp.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public object ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public object ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }
    }
}