namespace Biblioteca.Modelos;

public class Libro
{
    private string _titulo = string.Empty;
    private string _autor = string.Empty;
    private string _isbn = string.Empty;
    private int _stock;

    public int Id { get; set; }

    public string Titulo
    {
        get => _titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El título del libro es obligatorio.", nameof(Titulo));
            _titulo = value.Trim();
        }
    }

    public string Autor
    {
        get => _autor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El autor del libro es obligatorio.", nameof(Autor));
            _autor = value.Trim();
        }
    }

    public string Isbn
    {
        get => _isbn;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El código/ISBN es obligatorio.", nameof(Isbn));
            _isbn = value.Trim();
        }
    }

    public int Stock
    {
        get => _stock;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Stock), "El stock no puede ser negativo.");
            _stock = value;
        }
    }

    public bool Disponible => _stock > 0;

    public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}