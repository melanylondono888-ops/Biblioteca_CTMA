namespace Biblioteca.Modelos;

public class Prestamo
{
    private string _aprendizNombre = string.Empty;
    private DateTime _fechaPrestamo = DateTime.Today;
    private DateTime? _fechaDevolucion;

    public int Id { get; set; }

    public int LibroId { get; set; }
    public Libro? Libro { get; set; }

    public string AprendizNombre
    {
        get => _aprendizNombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del aprendiz o usuario es obligatorio.", nameof(AprendizNombre));
            _aprendizNombre = value.Trim();
        }
    }

    public DateTime FechaPrestamo
    {
        get => _fechaPrestamo;
        set => _fechaPrestamo = value;
    }

    public DateTime? FechaDevolucion
    {
        get => _fechaDevolucion;
        set
        {
            if (value.HasValue && value.Value.Date < _fechaPrestamo.Date)
                throw new ArgumentException("La fecha de devolución no puede ser anterior a la fecha de préstamo.", nameof(FechaDevolucion));
            _fechaDevolucion = value;
        }
    }

    public bool EstaDevuelto => _fechaDevolucion.HasValue;
}