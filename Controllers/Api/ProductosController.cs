using DulceCanastaModulo4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly DulceCanastaContext _context;

    public ProductosController(DulceCanastaContext context)
    {
        _context = context;
    }

    // DTO simple, incluye nombre de categoría para que el catálogo sea útil
    public sealed record ProductoDto(
        int ProductoId,
        string Nombre,
        string? Descripcion,
        decimal Precio,
        int Stock,
        string TipoVenta,
        bool Activo,
        DateTime FechaRegistro,
        string? ImagenUrl,
        int CategoriaId,
        string? CategoriaNombre
    );

    /// <summary>
    /// Obtiene la lista de productos (por defecto: activos y con stock).
    /// GET: /api/productos
    /// GET: /api/productos?soloActivos=false
    /// GET: /api/productos?soloConStock=false
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos(
        [FromQuery] bool soloActivos = true,
        [FromQuery] bool soloConStock = true)
    {
        var query = _context.Productos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .AsQueryable();

        if (soloActivos)
            query = query.Where(p => p.Activo);

        if (soloConStock)
            query = query.Where(p => p.Stock > 0);

        var productos = await query
            .OrderBy(p => p.Nombre)
            .Select(p => new ProductoDto(
                p.ProductoId,
                p.Nombre,
                p.Descripcion,
                p.Precio,
                p.Stock,
                p.TipoVenta,
                p.Activo,
                p.FechaRegistro,
                p.ImagenUrl,
                p.CategoriaId,
                p.Categoria != null ? p.Categoria.Nombre : null
            ))
            .ToListAsync();

        return Ok(productos);
    }

    /// <summary>
    /// Obtiene un producto por id.
    /// GET: /api/productos/{id}
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoDto>> GetProductoById(int id)
    {
        var producto = await _context.Productos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .Where(p => p.ProductoId == id)
            .Select(p => new ProductoDto(
                p.ProductoId,
                p.Nombre,
                p.Descripcion,
                p.Precio,
                p.Stock,
                p.TipoVenta,
                p.Activo,
                p.FechaRegistro,
                p.ImagenUrl,
                p.CategoriaId,
                p.Categoria != null ? p.Categoria.Nombre : null
            ))
            .FirstOrDefaultAsync();

        if (producto is null)
            return NotFound(new { message = $"Producto con id={id} no encontrado." });

        return Ok(producto);
    }
}
