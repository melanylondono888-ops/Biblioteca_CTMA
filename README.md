# [Nombre del Proyecto — ej. BiblioSENA Desktop]

Aplicación de escritorio desarrollada en **C# (.NET / Windows Forms)** con arquitectura en capas, **SQLite** y **Entity Framework Core**, diseñada para gestionar el catálogo de libros y los préstamos de la **Biblioteca del centro de formación**.

## Caso e integrantes

- **Caso seleccionado:** Biblioteca del centro de formación (`Libro` → `Préstamo`)
- **Integrantes y roles:**
  - **[Melany]** (`melanylondono888-ops`) — **Líder técnico**, ventanas principales y documentación (`README.md`)
  - **[Dainer]** (`AlexanderRm16`) — **Modelos y datos** (entidades, relación, `DbContext` y repositorios)
  - **[Jhonatan]** (`jhonatandev53`) — **Servicios** (reglas de negocio, validaciones y reportes con LINQ)

---

## Arquitectura y requisitos del proyecto

- **Solución en capas:** `Modelos`, `Datos`, `Servicios` y `Escritorio` (Windows Forms).
- **Base de datos:** SQLite con EF Core y relación uno a muchos (`Libro` → `Préstamo`), seleccionando el libro mediante un `ComboBox` al registrar o editar un préstamo.
- **POO y validaciones:** Encapsulamiento con validación de datos, manejo seguro de excepciones para evitar cierres inesperados por entradas inválidas, y herencia o interfaz (ej. interfaz genérica de repositorio / clase base de entidad).
- **Reportes con LINQ:** Al menos 2 reportes visibles en la interfaz (por ejemplo: préstamos activos/vencidos y libros más prestados o disponibilidad por categoría).

---

## Funcionalidades, formularios y reportes

### Formularios
- **Menú / Ventana principal (`FrmPrincipal`):** Navegación hacia los módulos de libros, préstamos y reportes.
- **Gestión de libros (`FrmLibros`):** Crear, consultar, editar y eliminar libros (título, autor, código/ISBN, stock o estado).
- **Gestión de préstamos (`FrmPrestamos`):** Registrar préstamos seleccionando el libro desde un `ComboBox`, consultar historial y registrar devoluciones.
- **Reportes (`FrmReportes`):** Visualización de consultas y métricas generadas con LINQ.

### Reportes con LINQ
1. **Préstamos activos y estado de devolución:** Lista los préstamos vigentes, aprendiz/usuario, fecha de préstamo y libro asociado.
2. **Libros más prestados / Resumen por libro:** Agrupa y ordena los libros según la cantidad de préstamos registrados.

---

## Reparto de archivos por integrante

| Integrante | Rol | Clases / Archivos | Formularios (`Forms`) |
| :--- | :--- | :--- | :--- |
| **Melany** | Líder técnico + Ventanas y docs | `AppDbContext.cs`, configuración de solución y `README.md` | `FrmPrincipal.cs` (y `[FrmReporte...cs]`) |
| **Dainer** | Modelos y datos | `Libro.cs`, `Prestamo.cs`, `IRepositorio.cs`, `LibroRepository.cs`, `PrestamoRepository.cs` | `FrmLibros.cs` |
| **Jhonatan** | Servicios | `LibroService.cs`, `PrestamoService.cs`, `ReporteService.cs` | `FrmPrestamos.cs` |

---

## Modelo de base de datos (`Libro` → `Préstamo`)

Un **Libro** puede tener muchos **Préstamos** (`1:N`), y cada **Préstamo** pertenece a un único **Libro** (seleccionado en la interfaz mediante un `ComboBox`).

```mermaid
erDiagram
    LIBRO ||--o{ PRESTAMO : "tiene"
    LIBRO {
        int Id PK
        string Codigo
        string Titulo
        string Autor
        int CantidadDisponible
    }
    PRESTAMO {
        int Id PK
        int LibroId FK
        string NombreAprendiz
        DateTime FechaPrestamo
        DateTime FechaDevolucion
        bool Devuelto
    }

