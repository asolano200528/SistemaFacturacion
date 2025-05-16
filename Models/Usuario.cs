using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        private int id;
        private string nombre, estado, contrasena, confirmarContrasena, genero, cedula, fechaRegistro, nombreUsuario;

        public Usuario(int id, string nombre, string estado, string contrasena, string confirmarContrasena, string genero, string cedula, string fechaRegistro, string nombreUsuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
            this.contrasena = contrasena;
            this.confirmarContrasena = confirmarContrasena;
            this.genero = genero;
            this.cedula = cedula;
            this.fechaRegistro = fechaRegistro;
            this.nombreUsuario = nombreUsuario;
        }

        public Usuario()
        {
            this.id = 0;
            this.nombre = "";
            this.estado = "";
            this.contrasena = "";
            this.confirmarContrasena = "";
            this.genero = "";
            this.cedula = "";
            this.fechaRegistro = DateTime.Now.ToString("yyyy-MM-dd");
            this.nombreUsuario = "";
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }

        [NotMapped]
        public string ConfirmarContrasena { get => confirmarContrasena; set => confirmarContrasena = value; }

        public string Genero { get => genero; set => genero = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }

    }
}
