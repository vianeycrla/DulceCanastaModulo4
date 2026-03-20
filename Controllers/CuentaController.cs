using DulceCanastaModulo4.Data;
using DulceCanastaModulo4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Controllers
{
    public class CuentaController : Controller
    {
        private readonly DulceCanastaContext _context;

        public CuentaController(DulceCanastaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == model.Email
                                  && u.PasswordHash == model.Password
                                  && u.Activo);

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View(model);
            }

            HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
            HttpContext.Session.SetString("UsuarioNombre", usuario.NombreCompleto);
            HttpContext.Session.SetString("Rol", usuario.Rol);

            TempData["Mensaje"] = $"Bienvenida, {usuario.Nombre}.";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public IActionResult Registro(Usuario model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var correoExistente = _context.Usuarios.Any(u => u.Email == model.Email);
            if (correoExistente)
            {
                ModelState.AddModelError("Email", "Ese correo ya está registrado.");
                return View(model);
            }

            model.Rol = "Cliente";
            model.Activo = true;
            model.FechaRegistro = DateTime.Now;

            _context.Usuarios.Add(model);
            _context.SaveChanges();

            TempData["Mensaje"] = "Tu cuenta fue creada correctamente. Ahora ya puedes iniciar sesión.";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Mensaje"] = "Sesión cerrada correctamente.";
            return RedirectToAction("Index", "Home");
        }
    }
}