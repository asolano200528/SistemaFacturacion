using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        private int id;
        private string cedula, nombre, tipo, correo, telefono;

        public int Id { get => id; set => id = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cliente(int id, string cedula, string nombre, string tipo, string correo, string telefono)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.tipo = tipo;
            this.correo = correo;
            this.telefono = telefono;
        }

        public Cliente()
        {
            this.id = 0;
            this.cedula = "";
            this.nombre = "";
            this.tipo = "";
            this.correo = "";
            this.telefono = "";
        }



    }
}
