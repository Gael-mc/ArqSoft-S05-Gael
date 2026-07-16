namespace CitasApp.Domain.Interfaces
{
    public interface IJsonFileStore
    {
        List<T> Leer<T>(string nombreArchivo);
    }
}