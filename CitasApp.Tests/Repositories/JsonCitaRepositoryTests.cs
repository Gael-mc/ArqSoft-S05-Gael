using CitasApp.Repositories;
using CitasApp.Tests.Fakes;
using Xunit;

namespace CitasApp.Tests.Repositories
{
    public class JsonCitaRepositoryTests
    {
        [Fact]
        public void ObtenerTodos_ConCitasEnElStore_MapeaCorrectamenteFechaYHora()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("citas.json", new List<CitaJson>
            {
                new()
                {
                    Id = 1,
                    PacienteId = 1,
                    MedicoId = 2,
                    Fecha = "2026-07-20",
                    Hora = "10:00",
                    Motivo = "Consulta",
                    Estado = "Pendiente"
                }
            });
            var repo = new JsonCitaRepository(store);

            // Act
            var citas = repo.ObtenerTodos();

            // Assert
            var cita = Assert.Single(citas);
            Assert.Equal(new DateOnly(2026, 7, 20), cita.Fecha);
            Assert.Equal(new TimeOnly(10, 0), cita.Hora);
            Assert.Equal("Pendiente", cita.Estado);
        }

        [Fact]
        public void ObtenerPorPaciente_ConVariasCitas_FiltraSoloLasDelPacienteIndicado()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("citas.json", new List<CitaJson>
            {
                new() { Id = 1, PacienteId = 1, MedicoId = 2, Fecha = "2026-07-20", Hora = "10:00", Motivo = "Consulta", Estado = "Pendiente" },
                new() { Id = 2, PacienteId = 2, MedicoId = 2, Fecha = "2026-07-21", Hora = "11:00", Motivo = "Revisión", Estado = "Pendiente" },
                new() { Id = 3, PacienteId = 1, MedicoId = 3, Fecha = "2026-07-22", Hora = "09:30", Motivo = "Seguimiento", Estado = "Pendiente" }
            });
            var repo = new JsonCitaRepository(store);

            // Act
            var citasDelPaciente = repo.ObtenerPorPaciente(1);

            // Assert
            Assert.Equal(2, citasDelPaciente.Count);
            Assert.All(citasDelPaciente, c => Assert.Equal(1, c.PacienteId));
        }

        [Fact]
        public void ObtenerTodos_SinCitasEnElStore_RegresaListaVacia()
        {
            // Arrange
            var store = new FakeJsonFileStore();
            store.Configurar("citas.json", new List<CitaJson>());
            var repo = new JsonCitaRepository(store);

            // Act
            var citas = repo.ObtenerTodos();

            // Assert
            Assert.Empty(citas);
        }
    }
}
