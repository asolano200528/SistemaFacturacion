using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        using (var db = new Proyecto.Models.Service())
        {
            db.Database.CreateIfNotExists();

            if (!db.Usuarios.Any())
            {
                db.Usuarios.Add(new Proyecto.Models.Usuario
                {
                    NombreUsuario = "admin",
                    Contrasena = "1234",
                    Estado = "Activo"
                });

                db.SaveChanges();
            }
        }


        var nombreUsuario = HttpContext.Session.GetString("Nombre");
        if (nombreUsuario != null)
            ViewBag.Nombre = nombreUsuario;
        else
            return RedirectToAction("Login", "Usuario");

        return View();
    }

    public IActionResult AcercaDe()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
