using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ProductoController : Controller
    {
        private Service service = new Service();
        
        
        // GET: ProductoController
        public ActionResult Index()
        {
            var productos = service.MostrarProductos();
            return View(productos);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    producto.Codigo = producto.GenerarCodigo();
                    producto.Precio = producto.CalcularPrecioFinal();
                    service.AgregarProducto(producto);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View(producto);
            }
            return View(producto);
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = service.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            try
            {
                
                producto.Precio = producto.CalcularPrecioFinal();
                service.EditarProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(producto);
            }
            
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = service.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
           
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var producto = service.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound(); 
            }

            try
            {
                service.EliminarProducto(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(producto); 
            }
        }

        public ActionResult OutOfStock()
        {
            var productosAgotados = service.ObtenerProductosAgotados();

            if (productosAgotados == null || productosAgotados.Count == 0)
            {
                ViewBag.Mensaje = "No hay productos fuera de stock en este momento.";
                return View(new List<Producto>()); 
            }

            return View(productosAgotados);
        }


    }
}
