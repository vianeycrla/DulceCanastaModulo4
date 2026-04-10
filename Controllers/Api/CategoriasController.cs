using DulceCanastaModulo4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly DulceCanastaContext _context;

    public CategoriasController(DulceCanastaContext context)
    {
        _context = context;
    }

    public sealed record CategoriaDto(
        int CategoriaId,
        string Nombre,
        string? Descripcion,
        bool Activo,
        int TotalProductos
    );

    /// Obtiene la lista de categorías (por defecto solo activas).
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias([FromQuery] bool soloActivas = true)
    {
        var query = _context.Categorias.AsNoTracking();

        if (soloActivas)
            query = query.Where(c => c.Activo);

        var categorias = await query
            .OrderBy(c => c.Nombre)
            .Select(c => new CategoriaDto(
                c.CategoriaId,
                c.Nombre,
                c.Descripcion,
                c.Activo,
                c.Productos.Count
            ))
            .ToListAsync();

        return Ok(categorias);
    }

    /// Obtiene una categoría por id.
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> GetCategoriaById(int id)
    {
        var categoria = await _context.Categorias
            .AsNoTracking()
            .Where(c => c.CategoriaId == id)
            .Select(c => new CategoriaDto(
                c.CategoriaId,
                c.Nombre,
                c.Descripcion,
                c.Activo,
                c.Productos.Count
            ))
            .FirstOrDefaultAsync();

        if (categoria is null)
            return NotFound(new { message = $"Categoría con id={id} no encontrada." });

        return Ok(categoria);
    }
}
