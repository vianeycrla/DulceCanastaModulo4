using DulceCanastaModulo4.Data;
using DulceCanastaModulo4.Models;
using Microsoft.AspNetCore.Mvc;

namespace DulceCanastaModulo4.Controllers
{
    public class PerfilController : Controller
    {
        private readonly DulceCanastaContext _context;

        public PerfilController(DulceCanastaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Cuenta");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId.Value);
            if (usuario == null)
            {
                return RedirectToAction("Login", "Cuenta");
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Guardar(Usuario model)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null || usuarioId != model.UsuarioId)
            {
                return RedirectToAction("Login", "Cuenta");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == model.UsuarioId);
            if (usuario == null)
            {
                return RedirectToAction("Login", "Cuenta");
            }

            usuario.Nombre = model.Nombre;
            usuario.ApellidoPaterno = model.ApellidoPaterno;
            usuario.ApellidoMaterno = model.ApellidoMaterno;
            usuario.FechaNacimiento = model.FechaNacimiento;
            usuario.Telefono = model.Telefono;
            usuario.FotoUrl = model.FotoUrl;
            usuario.Direccion = model.Direccion;
            usuario.Ciudad = model.Ciudad;
            usuario.CodigoPostal = model.CodigoPostal;
            usuario.Referencias = model.Referencias;

            _context.SaveChanges();

            HttpContext.Session.SetString("UsuarioNombre", usuario.NombreCompleto);
            TempData["Mensaje"] = "Tu perfil se actualizó correctamente.";

            return RedirectToAction("Index");
        }
    }
}