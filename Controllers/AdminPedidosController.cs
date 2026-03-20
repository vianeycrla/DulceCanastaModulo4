using DulceCanastaModulo4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers;

public class AdminPedidosController : Controller
{
    private readonly DulceCanastaContext _context;

    public AdminPedidosController(DulceCanastaContext context)
    {
        _context = context;
    }

    private bool EsAdmin() => HttpContext.Session.GetString("Rol") == "Admin";

    public async Task<IActionResult> Index()
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var pedidos = await _context.Pedidos.OrderByDescending(p => p.FechaPedido).ToListAsync();
        return View(pedidos);
    }

    public async Task<IActionResult> Details(int id)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var pedido = await _context.Pedidos
            .Include(p => p.Detalles)
            .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(p => p.PedidoId == id);

        if (pedido == null) return NotFound();

        return View(pedido);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CambiarEstatus(int pedidoId, string estatus)
    {
        if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");

        var pedido = await _context.Pedidos.FindAsync(pedidoId);
        if (pedido == null) return NotFound();

        pedido.Estatus = estatus;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id = pedidoId });
    }
}
