using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ClienteController : Controller
    {
        private Service service = new Service();

        // GET: ClienteController
        public ActionResult Index()
        {
            var clientes = service.MostrarClientes();
            return View(clientes);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.AgregarCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(cliente);
            }
            return View(cliente);
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = service.ObtenerClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                service.EditarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = service.ObtenerClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = service.ObtenerClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            try
            {
                service.EliminarCliente(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        public ActionResult BuscarCedula()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarCedula(string cedula)
        {
            var clientePorCedula = service.ObtenerClientePorCedula(cedula);

            if (clientePorCedula == null || clientePorCedula.Count == 0)
            {
                ViewBag.Mensaje = "No Se encontro ningun cliente con esa cedula";
                return View(new List<Cliente>());
            }

            return View(clientePorCedula);
        }

        public ActionResult BuscarTipo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarTipo(string tipo)
        {
            var clientePorTipo = service.ObtenerClientesPorTipo(tipo);

            if (clientePorTipo == null || clientePorTipo.Count == 0)
            {
                ViewBag.Mensaje = "No Se encontro ningun cliente con ese tipo";
                return View(new List<Cliente>());
            }

            return View(clientePorTipo);
        }


    }
}
