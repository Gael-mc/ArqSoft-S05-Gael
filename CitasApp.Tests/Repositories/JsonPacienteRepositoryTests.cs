using CitasApp.Domain.Models;
using CitasApp.Repositories;
using CitasApp.Tests.Fakes;
using Xunit;

namespace CitasApp.Tests.Repositories
{
    public class JsonPacienteRepositoryTests
    {
        [Fact]
        public void ObtenerTodos_ConPacientesEnElStore_RegresaLaListaCompleta()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("pacientes.json", new List<Paciente>
            {
                new() { Id = 1, Nombre = "Carla", Apellido = "Diaz", Email = "carla@mail.com", Telefono = "555-0001" },
                new() { Id = 2, Nombre = "Marco", Apellido = "Leon", Email = "marco@mail.com", Telefono = "555-0002" }
            });
            var repo = new JsonPacienteRepository(store);

            // Act
            var pacientes = repo.ObtenerTodos();

            // Assert
            Assert.Equal(2, pacientes.Count);
            Assert.Contains(pacientes, p => p.Email == "marco@mail.com");
        }

        [Fact]
        public void ObtenerPorId_ConIdExistente_RegresaElPacienteCorrecto()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("pacientes.json", new List<Paciente>
            {
                new() { Id = 1, Nombre = "Carla", Apellido = "Diaz", Email = "carla@mail.com", Telefono = "555-0001" }
            });
            var repo = new JsonPacienteRepository(store);

            // Act
            var paciente = repo.ObtenerPorId(1);

            // Assert
            Assert.NotNull(paciente);
            Assert.Equal("Diaz", paciente!.Apellido);
        }

        [Fact]
        public void ObtenerPorId_ConIdInexistente_RegresaNull()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("pacientes.json", new List<Paciente>
            {
                new() { Id = 1, Nombre = "Carla", Apellido = "Diaz", Email = "carla@mail.com", Telefono = "555-0001" }
            });
            var repo = new JsonPacienteRepository(store);

            // Act
            var paciente = repo.ObtenerPorId(50);

            // Assert
            Assert.Null(paciente);
        }
    }
}
