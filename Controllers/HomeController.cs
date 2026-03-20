using Microsoft.AspNetCore.Mvc;

namespace DulceCanastaModulo4.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
