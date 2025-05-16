using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        Service service = new Service();

        // GET: UsuarioController
        public ActionResult Index()
        {
            var usuarios = service.MostrarUsuarios();
            return View(usuarios);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.AgregarUsuario(usuarios);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(usuarios);
            }
            return View(usuarios);
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuarios = service.ObtenerUsuarioPorId(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuarios)
        {
            try
            {
                service.EditarUsuario(usuarios);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(usuarios);
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            var usuarios = service.ObtenerUsuarioPorId(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuarios = service.ObtenerUsuarioPorId(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            try
            {
                service.EliminarUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(usuarios);
            }
        }

        // GET: UsuarioController/BuscarCedula
        public ActionResult BuscarCedula()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarCedula(string cedula)
        {
            var usuariosPorCedula = service.ObtenerUsuarioPorCedula(cedula);
            if (usuariosPorCedula == null || usuariosPorCedula.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron usuarios con la cédula proporcionada.";
                return View(new List<Usuario>());
            }
            return View(usuariosPorCedula);
        }

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string usuario, string pass)
        {
            try
            {
                var usuarioLogueado = service.validarLogin(usuario, pass);
                HttpContext.Session.SetString("Nombre", usuarioLogueado.Nombre);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al iniciar sesión: " + ex.Message;
            }
            return View();

        }
    }
}
