using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Datos;

public class LibroRepository : IRepositorio<Libro>
{
    private readonly AppDbContext _context;

    public LibroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Libro>> ObtenerTodosAsync()
    {
        return await _context.Libros
            .AsNoTracking()
            .OrderBy(l => l.Titulo)
            .ToListAsync();
    }

    public async Task<Libro?> ObtenerPorIdAsync(int id)
    {
        return await _context.Libros
            .Include(l => l.Prestamos)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task AgregarAsync(Libro entidad)
    {
        await _context.Libros.AddAsync(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Libro entidad)
    {
        _context.Libros.Update(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro is null) return;

        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Libro>> BuscarAsync(string filtro)
    {
        if (string.IsNullOrWhiteSpace(filtro))
            return await ObtenerTodosAsync();

        var termino = filtro.Trim().ToLower();
        return await _context.Libros
            .AsNoTracking()
            .Where(l => l.Titulo.ToLower().Contains(termino)
                     || l.Autor.ToLower().Contains(termino)
                     || l.Isbn.ToLower().Contains(termino))
            .OrderBy(l => l.Titulo)
            .ToListAsync();
    }
}