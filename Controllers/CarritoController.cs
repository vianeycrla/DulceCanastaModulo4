using System.Text.Json;
using DulceCanastaModulo4.Data;
using DulceCanastaModulo4.Models;
using DulceCanastaModulo4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers
{
    public class CarritoController : Controller
    {
        private readonly DulceCanastaContext _context;
        private const string CartKey = "CARRITO_SESSION";

        public CarritoController(DulceCanastaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = ObtenerCarrito();
            return View(items);
        }

        [HttpPost]
        public IActionResult Agregar(int productoId)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == productoId && p.Activo);
            if (producto == null)
            {
                TempData["Mensaje"] = "El producto no existe.";
                return RedirectToAction("Index", "Catalogo");
            }

            var carrito = ObtenerCarrito();
            var existente = carrito.FirstOrDefault(x => x.ProductoId == productoId);

            if (existente != null)
            {
                existente.Cantidad++;
                existente.Subtotal = existente.Cantidad * existente.PrecioUnitario;
            }
            else
            {
                carrito.Add(new SessionCartItemViewModel
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    ImagenUrl = producto.ImagenUrl,
                    Cantidad = 1,
                    PrecioUnitario = producto.Precio,
                    Subtotal = producto.Precio
                });
            }

            GuardarCarrito(carrito);
            TempData["Mensaje"] = "Producto agregado a la canasta.";
            return RedirectToAction("Index", "Catalogo");
        }

        [HttpPost]
        public IActionResult Quitar(int productoId)
        {
            var carrito = ObtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.ProductoId == productoId);

            if (item != null)
            {
                carrito.Remove(item);
                GuardarCarrito(carrito);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
            {
                TempData["Mensaje"] = "Inicia sesión para continuar con tu pedido.";
                return RedirectToAction("Login", "Cuenta");
            }

            var carrito = ObtenerCarrito();
            if (!carrito.Any())
            {
                TempData["Mensaje"] = "Tu canasta está vacía.";
                return RedirectToAction("Index", "Catalogo");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId.Value);
            if (usuario == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Cuenta");
            }

            var vm = new CheckoutViewModel
            {
                NombreCliente = usuario.Nombre,
                ApellidoPaternoCliente = usuario.ApellidoPaterno,
                ApellidoMaternoCliente = usuario.ApellidoMaterno,
                Telefono = usuario.Telefono ?? string.Empty,
                FechaNacimientoCliente = usuario.FechaNacimiento,
                DireccionEntrega = usuario.Direccion,
                TipoEntrega = string.IsNullOrWhiteSpace(usuario.Direccion) ? "RecogerEnTienda" : "Domicilio",
                Total = carrito.Sum(x => x.Subtotal),
                Items = carrito
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
            {
                TempData["Mensaje"] = "Inicia sesión para continuar con tu pedido.";
                return RedirectToAction("Login", "Cuenta");
            }

            var carrito = ObtenerCarrito();
            if (!carrito.Any())
            {
                TempData["Mensaje"] = "Tu canasta está vacía.";
                return RedirectToAction("Index", "Catalogo");
            }

            if (model.TipoEntrega == "Domicilio" && string.IsNullOrWhiteSpace(model.DireccionEntrega))
            {
                ModelState.AddModelError("DireccionEntrega", "La dirección es obligatoria si eliges entrega a domicilio.");
            }

            if (!ModelState.IsValid)
            {
                model.Items = carrito;
                model.Total = carrito.Sum(x => x.Subtotal);
                return View(model);
            }

            var pedido = new Pedido
            {
                UsuarioId = usuarioId.Value,
                FechaPedido = DateTime.Now,
                Estatus = "Pendiente",
                Total = carrito.Sum(x => x.Subtotal),
                NombreCliente = model.NombreCliente,
                ApellidoPaternoCliente = model.ApellidoPaternoCliente,
                ApellidoMaternoCliente = model.ApellidoMaternoCliente,
                Telefono = model.Telefono,
                FechaNacimientoCliente = model.FechaNacimientoCliente,
                TipoEntrega = model.TipoEntrega,
                DireccionEntrega = model.TipoEntrega == "Domicilio" ? model.DireccionEntrega : null,
                Notas = model.Notas
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            foreach (var item in carrito)
            {
                var detalle = new PedidoDetalle
                {
                    PedidoId = pedido.PedidoId,
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = item.Subtotal
                };

                _context.PedidoDetalles.Add(detalle);
            }

            _context.SaveChanges();

            HttpContext.Session.Remove(CartKey);

            TempData["Mensaje"] = $"Pedido generado correctamente. Folio: {pedido.PedidoId}";
            return RedirectToAction("Confirmacion", new { id = pedido.PedidoId });
        }

        [HttpGet]
        public IActionResult Confirmacion(int id)
        {
            var pedido = _context.Pedidos
    .Include(p => p.Detalles!)
    .ThenInclude(d => d.Producto)
    .AsEnumerable()
    .FirstOrDefault(p => p.PedidoId == id);

            if (pedido == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(pedido);
        }

        private List<SessionCartItemViewModel> ObtenerCarrito()
        {
            var data = HttpContext.Session.GetString(CartKey);
            if (string.IsNullOrEmpty(data))
            {
                return new List<SessionCartItemViewModel>();
            }

            return JsonSerializer.Deserialize<List<SessionCartItemViewModel>>(data) ?? new List<SessionCartItemViewModel>();
        }

        private void GuardarCarrito(List<SessionCartItemViewModel> carrito)
        {
            HttpContext.Session.SetString(CartKey, JsonSerializer.Serialize(carrito));
        }
    }
}