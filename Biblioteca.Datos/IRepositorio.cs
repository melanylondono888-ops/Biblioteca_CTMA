namespace Biblioteca.Datos;

public interface IRepositorio<T> where T : class
{
    Task<List<T>> ObtenerTodosAsync();
    Task<T?> ObtenerPorIdAsync(int id);
    Task AgregarAsync(T entidad);
    Task ActualizarAsync(T entidad);
    Task EliminarAsync(int id);
}