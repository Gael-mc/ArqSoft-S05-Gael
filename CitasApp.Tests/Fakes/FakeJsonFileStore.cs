using CitasApp.Domain.Interfaces;

namespace CitasApp.Tests.Fakes
{
    /// <summary>
    /// Doble de prueba para IJsonFileStore. Permite inyectar datos en memoria
    /// para los repositorios sin tocar el sistema de archivos real.
    /// </summary>
    public class FakeJsonFileStore : IJsonFileStore
    {
        private readonly Dictionary<string, object> _datos = new();

        /// <summary>
        /// Configura qué lista debe devolver el store cuando se pida
        /// el archivo <paramref name="nombreArchivo"/>.
        /// </summary>
        public void Configurar<T>(string nombreArchivo, List<T> datos)
        {
            _datos[nombreArchivo] = datos!;
        }

        public List<T> Leer<T>(string nombreArchivo)
        {
            if (_datos.TryGetValue(nombreArchivo, out var datos) && datos is List<T> tipado)
            {
                return tipado;
            }

            return new List<T>();
        }
    }
}
