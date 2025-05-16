using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    [Table("Facturas")]
    public class Factura
    {
        private int id;
        private string cedulaCliente, nombreCliente, codigoProducto, nombreProducto, fechaFactura;
        private double cantidadProducto, montoTotal;


        public int Id { get => id; set => id = value; }
        public string CedulaCliente { get => cedulaCliente; set => cedulaCliente = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string FechaFactura { get => fechaFactura; set => fechaFactura = value; }
        public double CantidadProducto { get => cantidadProducto; set => cantidadProducto = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }

        public Factura(int id, string cedulaCliente, string nombreCliente, string codigoProducto, string nombreProducto, string fechaFactura, double cantidadProducto, double montoTotal)
        {
            this.id = id;
            this.cedulaCliente = cedulaCliente;
            this.nombreCliente = nombreCliente;
            this.codigoProducto = codigoProducto;
            this.nombreProducto = nombreProducto;
            this.fechaFactura = fechaFactura;
            this.cantidadProducto = cantidadProducto;
            this.montoTotal = montoTotal;
        }

        public Factura()
        {
            this.id = 0;
            this.cedulaCliente = "";
            this.nombreCliente = "";
            this.codigoProducto = "";
            this.nombreProducto = "";
            this.fechaFactura = DateTime.Now.ToString("yyyy-MM-dd");
            this.cantidadProducto = 0.0;
            this.montoTotal = 0.0;
        }

        
    }
}
