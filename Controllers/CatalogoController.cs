using DulceCanastaModulo4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers;

public class CatalogoController : Controller
{
    private readonly DulceCanastaContext _context;

    public CatalogoController(DulceCanastaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? categoriaId)
    {
        ViewBag.Categorias = await _context.Categorias.Where(c => c.Activo).ToListAsync();

        var query = _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.Activo && p.Stock > 0)
            .AsQueryable();

        if (categoriaId.HasValue)
        {
            query = query.Where(p => p.CategoriaId == categoriaId.Value);
        }

        var productos = await query.OrderBy(p => p.Nombre).ToListAsync();
        return View(productos);
    }

    public async Task<IActionResult> Detalle(int id)
    {
        var producto = await _context.Productos.Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.ProductoId == id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }
}
