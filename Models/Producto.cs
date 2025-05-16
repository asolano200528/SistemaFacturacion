using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    [Table("Productos")] 
    public class Producto
    {
        private int id, cantidad;
        private string nombre, tipo, promocion, codigo, fechaRegistro;
        private double precio;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Promocion { get => promocion; set => promocion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }


        public Producto(int id, double precio, int cantidad, string nombre, string tipo, string promocion, string codigo, string fechaRegistro)
        {
            this.id = id;
            this.precio = precio;
            this.cantidad = cantidad;
            this.nombre = nombre;
            this.tipo = tipo;
            this.promocion = promocion;
            this.codigo = codigo;
            this.fechaRegistro = fechaRegistro;
        }

        public Producto() 
        {
            this.id = 0;
            this.precio = 0.0;
            this.cantidad = 0;
            this.nombre = "";
            this.tipo = "";
            this.promocion = "";
            this.codigo = "";
            this.fechaRegistro = DateTime.Now.ToString("yyyy-MM-dd");
        }


        public double CalcularPrecioFinal() 
        {
            double descuento = 0.0, iva = 0.0, precioFinal = 0.0;

            if (promocion == "Si") 
            {
                descuento = Precio * 0.10;
            }
            else if (promocion == "No")
            {
                descuento = 0.0;
            }

            precioFinal = Precio - descuento;

            iva = precioFinal * 0.13;

            precioFinal = precioFinal + iva;

            return precioFinal;

        }

        public string GenerarCodigo() 
        {
            char tipoLetra = Tipo.ToUpper()[0];
            string mes = fechaRegistro.Substring(5, 2);
            Random random = new Random();
            int numeroAleatorio = random.Next(10, 99);

            return tipoLetra + mes + numeroAleatorio.ToString();

        }

        
    }
}
