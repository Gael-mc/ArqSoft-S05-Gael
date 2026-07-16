using CitasApp.Domain.Interfaces;
using System.Text.Json;

namespace CitasApp.Infrastructure.Repositories
{
    public class JsonFileStore : IJsonFileStore
    {
        private readonly string _basePath;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonFileStore(string basePath)
        {
            _basePath = basePath;
        }

        public List<T> Leer<T>(string nombreArchivo)
        {
            var path = Path.Combine(_basePath, nombreArchivo);
            if (!File.Exists(path)) return new();
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new();
        }
    }
}