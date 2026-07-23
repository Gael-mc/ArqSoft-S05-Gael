using CitasApp.Domain.Models;
using CitasApp.Repositories;
using CitasApp.Tests.Fakes;
using Xunit;

namespace CitasApp.Tests.Repositories
{
    public class JsonMedicoRepositoryTests
    {
        [Fact]
        public void ObtenerTodos_ConMedicosEnElStore_RegresaLaListaCompleta()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("medicos.json", new List<Medico>
            {
                new() { Id = 1, Nombre = "Ana", Apellido = "Ruiz", Especialidad = "Pediatría", NumeroLicencia = "L-001" },
                new() { Id = 2, Nombre = "Luis", Apellido = "Soto", Especialidad = "Cardiología", NumeroLicencia = "L-002" }
            });
            var repo = new JsonMedicoRepository(store);

            // Act
            var medicos = repo.ObtenerTodos();

            // Assert
            Assert.Equal(2, medicos.Count);
            Assert.Contains(medicos, m => m.Nombre == "Ana" && m.Especialidad == "Pediatría");
        }

        [Fact]
        public void ObtenerPorId_ConIdExistente_RegresaElMedicoCorrecto()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("medicos.json", new List<Medico>
            {
                new() { Id = 1, Nombre = "Ana", Apellido = "Ruiz", Especialidad = "Pediatría", NumeroLicencia = "L-001" },
                new() { Id = 2, Nombre = "Luis", Apellido = "Soto", Especialidad = "Cardiología", NumeroLicencia = "L-002" }
            });
            var repo = new JsonMedicoRepository(store);

            // Act
            var medico = repo.ObtenerPorId(2);

            // Assert
            Assert.NotNull(medico);
            Assert.Equal("Luis", medico!.Nombre);
        }

        [Fact]
        public void ObtenerPorId_ConIdInexistente_RegresaNull()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("medicos.json", new List<Medico>
            {
                new() { Id = 1, Nombre = "Ana", Apellido = "Ruiz", Especialidad = "Pediatría", NumeroLicencia = "L-001" }
            });
            var repo = new JsonMedicoRepository(store);

            // Act
            var medico = repo.ObtenerPorId(99);

            // Assert
            Assert.Null(medico);
        }
    }
}
