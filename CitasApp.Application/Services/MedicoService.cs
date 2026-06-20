using CitasApp.Domain.Interfaces;

namespace CitasApp.Application.Services
{
    public class MedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository)
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