using DulceCanastaModulo4.Data;
using DulceCanastaModulo4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers;

public class AdminProductosController : Controller
{
    private readonly DulceCanastaContext _context;

    public AdminProductosController(DulceCanastaContext context)
    {
        _context = context;
    }

    private bool EsAdmin() => HttpContext.Session.GetString("Rol") == "Admin";

    public async Task<IActionResult> Index()
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var productos = await _context.Productos.Include(p => p.Categoria).OrderBy(p => p.Nombre).ToListAsync();
        return View(productos);
    }

    public async Task<IActionResult> Create()
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");
        await CargarCategorias();
        return View(new Producto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        if (!ModelState.IsValid)
        {
            await CargarCategorias();
            return View(producto);
        }

        producto.FechaRegistro = DateTime.Now;
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();

        await CargarCategorias();
        return View(producto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Producto producto)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");
        if (id != producto.ProductoId) return NotFound();

        if (!ModelState.IsValid)
        {
            await CargarCategorias();
            return View(producto);
        }

        _context.Update(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ProductoId == id);
        if (producto == null) return NotFound();

        return View(producto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCategorias()
    {
        var categorias = await _context.Categorias.Where(c => c.Activo).OrderBy(c => c.Nombre).ToListAsync();
        ViewBag.CategoriaId = new SelectList(categorias, "CategoriaId", "Nombre");
    }
}
