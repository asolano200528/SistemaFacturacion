using System.Data.Entity;

namespace Proyecto.Models
{
    public class Service : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Service() : base("CalvinKlein") 
        {
            
        }


        #region Metodos Producto
        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
            SaveChanges();
        }

        public List<Producto> MostrarProductos()
        {
            return Productos.ToList();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return Productos.Find(id);
        }

        public void EditarProducto(Producto producto)
        {
            var prod = Productos.Find(producto.Id);
            if (prod != null)
            {
                prod.Nombre = producto.Nombre;
                prod.Tipo = producto.Tipo;
                prod.Precio = producto.Precio;
                prod.Cantidad = producto.Cantidad;
                prod.Promocion = producto.Promocion;
                SaveChanges();
            }
        }

        public void EliminarProducto(int id)
        {
            var prod = Productos.Find(id);
            if (prod != null)
            {
                Productos.Remove(prod);
                SaveChanges();
            }
        }

        public List<Producto> ObtenerProductosAgotados()
        {
            var prodSinStock = Productos.Where(p => p.Cantidad == 0).ToList();
            return prodSinStock;
        }

        public void ActualizarStockRestar(string codigo, int cantidad)
        {
            var prod = Productos.FirstOrDefault(p => p.Codigo == codigo);
            if (prod != null)
            {
                prod.Cantidad = prod.Cantidad - cantidad;
                SaveChanges();
            }
        }

        public void ActualizarStockSumar(string codigo, int cantidad)
        {
            var prod = Productos.FirstOrDefault(p => p.Codigo == codigo);
            if (prod != null)
            {
                prod.Cantidad = prod.Cantidad + cantidad;
                SaveChanges();
            }
        }

        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            var codigoProducto = Productos.FirstOrDefault(p => p.Codigo == codigo);
            if (codigoProducto == null)
            {
                throw new Exception("El producto no existe");
            }
            return codigoProducto;
        }

        #endregion

        #region Metodos Cliente

        public void AgregarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
            SaveChanges();
        }

        public List<Cliente> MostrarClientes()
        {
            return Clientes.ToList();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return Clientes.Find(id);
        }

        public List<Cliente> ObtenerClientePorCedula(string cedula)
        {
            var clientes = Clientes.Where(c => c.Cedula == cedula).ToList();
            return clientes;

        }

        public void EditarCliente(Cliente cliente)
        {
            var clienteAEditar = Clientes.Find(cliente.Id);
            if (clienteAEditar != null)
            {
                clienteAEditar.Nombre = cliente.Nombre;
                clienteAEditar.Tipo = cliente.Tipo;
                clienteAEditar.Correo = cliente.Correo;
                clienteAEditar.Telefono = cliente.Telefono;
                SaveChanges();
            }
        }

        public void EliminarCliente(int id)
        {
            var clienteAEliminar = Clientes.Find(id);
            if (clienteAEliminar != null)
            {
                Clientes.Remove(clienteAEliminar);
                SaveChanges();
            }
        }

        public List<Cliente> ObtenerClientesPorTipo(string tipo)
        {
            var clientes = Clientes.Where(c => c.Tipo == tipo).ToList();
            return clientes;
        }

        #endregion

        #region Metodos Factura

        public void AgregarFactura(Factura factura)
        {
            Facturas.Add(factura);
            SaveChanges();
        }

        public List<Factura> MostrarFacturas()
        {
            return Facturas.ToList();
        }

        public Factura ObtenerFacturaPorId(int id)
        {
            return Facturas.Find(id);
        }

        //implementar metodo para editar factura
        public void EditarFactura(Factura factura)
        {
            var facturaExistente = Facturas.Find(factura.Id);
            if (facturaExistente != null)
            {
                facturaExistente.CedulaCliente = factura.CedulaCliente;
                facturaExistente.NombreCliente = factura.NombreCliente;
                facturaExistente.CodigoProducto = factura.CodigoProducto;
                facturaExistente.NombreProducto = factura.NombreProducto;
                facturaExistente.FechaFactura = factura.FechaFactura;
                facturaExistente.CantidadProducto = factura.CantidadProducto;
                facturaExistente.MontoTotal = factura.MontoTotal;

                SaveChanges();
            }
        }
        //implementar metodo para eliminar factura
        public void EliminarFactura(int id)
        {
            var factura = Facturas.Find(id);
            if (factura != null)
            {
                Facturas.Remove(factura);
                SaveChanges();
            }
        }
        public List<Factura> ObtenerFacturasPorMes(string mes)
        {
            string numeroMes = "";

            if (mes == "Enero")
            {
                numeroMes = "01";
            }
            else if (mes == "Febrero")
            {
                numeroMes = "02";
            }
            else if (mes == "Marzo")
            {
                numeroMes = "03";
            }
            else if (mes == "Abril")
            {
                numeroMes = "04";
            }
            else if (mes == "Mayo")
            {
                numeroMes = "05";
            }
            else if (mes == "Junio")
            {
                numeroMes = "06";
            }
            else if (mes == "Julio")
            {
                numeroMes = "07";
            }
            else if (mes == "Agosto")
            {
                numeroMes = "08";
            }
            else if (mes == "Septiembre")
            {
                numeroMes = "09";
            }
            else if (mes == "Octubre")
            {
                numeroMes = "10";
            }
            else if (mes == "Noviembre")
            {
                numeroMes = "11";
            }
            else if (mes == "Diciembre")
            {
                numeroMes = "12";
            }

            var facturas = Facturas.Where(f => f.FechaFactura.Substring(5, 2) == numeroMes).ToList();

            return facturas;
        }




        public void CalcularMontoTotal(Factura factura)
        {
            var producto = Productos.FirstOrDefault(p => p.Codigo == factura.CodigoProducto);
            if (producto != null)
            {
                factura.MontoTotal = factura.CantidadProducto * producto.Precio;
                SaveChanges();
            }
        }
        #endregion

        #region Metodos Usuario
        public void AgregarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
            SaveChanges();
        }

        public List<Usuario> MostrarUsuarios()
        {
            return Usuarios.ToList();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return Usuarios.Find(id);
        }

        public List<Usuario> ObtenerUsuarioPorCedula(string cedula)
        {
            var usuarios = Usuarios.Where(u => u.Cedula == cedula).ToList();
            return usuarios;
        }

        public void EditarUsuario(Usuario usuario)
        {
            var usuarioAEditar = Usuarios.Find(usuario.Id);
            if (usuarioAEditar != null)
            {
                usuarioAEditar.Nombre = usuario.Nombre;
                usuarioAEditar.Estado = usuario.Estado;
                usuarioAEditar.NombreUsuario = usuario.NombreUsuario;
                usuarioAEditar.Contrasena = usuario.Contrasena;
                SaveChanges();
            }
        }

        public void EliminarUsuario(int id)
        {
            var usuarioAEliminar = Usuarios.Find(id);
            if (usuarioAEliminar != null)
            {
                Usuarios.Remove(usuarioAEliminar);
                SaveChanges();
            }
        }

        public List<Usuario> ObtenerUsuariosPorEstado(string estado)
        {
            var usuarios = Usuarios.Where(u => u.Estado == estado).ToList();
            return usuarios;
        }

        public Usuario validarLogin(string user, string pass)
        {
            var usuarioLogueado = Usuarios.FirstOrDefault(u => u.NombreUsuario == user && u.Contrasena == pass);
            if (usuarioLogueado == null)
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }

            //Este es si el usuario lo ponen inactivo, el coso no te deja entrar
            if (usuarioLogueado.Estado != "Activo")
            {
                throw new Exception("Usuario inactivo. No puede acceder");
            }
            return usuarioLogueado;
        }


        #endregion
    }
}
