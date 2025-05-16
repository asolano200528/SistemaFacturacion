using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class FacturaController : Controller
    {
        private readonly Service service = new Service();

        // Mostrar todas las facturas
        public ActionResult Index()
        {
            var facturas = service.MostrarFacturas();
            return View(facturas);
        }



        // Formulario para crear factura
        public ActionResult Create()
        {
            ViewBag.Productos = service.MostrarProductos();
            return View();
        }

        // Guardar nueva factura
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Productos = service.MostrarProductos(); // Volver a asignar los productos
                return View(factura);
            }

            var producto = service.ObtenerProductoPorCodigo(factura.CodigoProducto);

            if (producto == null)
            {
                ViewBag.ErrorMessage = "El producto seleccionado no existe.";
                ViewBag.Productos = service.MostrarProductos(); // Volver a asignar los productos
                return View(factura);
            }

            if (factura.CantidadProducto > producto.Cantidad)
            {
                ViewBag.ErrorMessage = "No hay suficiente stock disponible.";
                ViewBag.Productos = service.MostrarProductos(); // Volver a asignar los productos
                return View(factura);
            }

            factura.MontoTotal = factura.CantidadProducto * producto.CalcularPrecioFinal();
            service.AgregarFactura(factura);
            service.ActualizarStockRestar(factura.CodigoProducto, (int)factura.CantidadProducto);

            return RedirectToAction(nameof(Index));
        }


        // Formulario para editar factura
        public ActionResult Edit(int id)
        {
            var factura = service.ObtenerFacturaPorId(id);
            if (factura == null)
                return NotFound();
            ViewBag.Productos = service.MostrarProductos();
            return View(factura);
        }

        // Guardar cambios en factura
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            try
            {
                var facturaOriginal = service.ObtenerFacturaPorId(factura.Id);
                if (facturaOriginal == null)
                {
                    return NotFound();
                }

                // Ajustar stock antes de la edición
                service.ActualizarStockSumar(facturaOriginal.CodigoProducto, (int)facturaOriginal.CantidadProducto);
                service.ActualizarStockRestar(factura.CodigoProducto, (int)factura.CantidadProducto);

                // Recalcular monto total
                service.CalcularMontoTotal(factura);

                // Guardar cambios
                service.EditarFactura(factura);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(factura);
            }
        }

        // Confirmar eliminación de factura
        public ActionResult Delete(int id)
        {
            var factura = service.ObtenerFacturaPorId(id);
            if (factura == null)
                return NotFound();

            return View(factura);
        }

        // Eliminar factura
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var factura = service.ObtenerFacturaPorId(id);
            if (factura != null)
            {
                service.EliminarFactura(id);

                // Restaurar stock del producto eliminado
                service.ActualizarStockSumar(factura.CodigoProducto, (int)factura.CantidadProducto);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult FacturacionDelMes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FacturacionDelMes(string mesSeleccionado)
        {
            var facturas = service.ObtenerFacturasPorMes(mesSeleccionado);
            return View(facturas);
        }

        public ActionResult BuscarFacturaId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarFacturaId(int idFactura)
        {
            var factura = service.ObtenerFacturaPorId(idFactura);
            if (factura == null)
            {
                ViewBag.ErrorMessage = "No se encontró ninguna factura con el ID ingresado.";
                return View();
            }
            return View(factura);
        }
    }
}