using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.DTO.Common
{
    public static class ValidarModelo
    {
        public static Cliente ValidarCliente(ClienteReq objCliente, Cliente existeCliente)
        {
            existeCliente.Cuit = objCliente.Cuit == null ? string.Empty : objCliente.Cuit;
            existeCliente.RazonSocial = objCliente.RazonSocial == null ? string.Empty : objCliente.RazonSocial ;
            existeCliente.Nombre = objCliente.Nombre == null ? string.Empty : objCliente.Nombre;
            existeCliente.Apellido = objCliente.Apellido == null ? string.Empty : objCliente.Apellido;
            existeCliente.Domicilio = objCliente.Domicilio == null ? string.Empty : objCliente.Domicilio;
            existeCliente.Localidad = objCliente.Localidad == null ? string.Empty : objCliente.Localidad;
            existeCliente.Provincia = objCliente.Provincia == null ? string.Empty : objCliente.Provincia;
            existeCliente.Telefono = objCliente.Telefono == null ? string.Empty : objCliente.Telefono;

            return existeCliente;
        }

        public static Proveedor ValidarProveedor(ProveedorReq objProveedor, Proveedor existeProveedor)
        {
            existeProveedor.Cuit = objProveedor.Cuit == null ? string.Empty : objProveedor.Cuit;
            existeProveedor.RazonSocial = objProveedor.RazonSocial == null ? string.Empty : objProveedor.RazonSocial;
            existeProveedor.Domicilio = objProveedor.Domicilio == null ? string.Empty : objProveedor.Domicilio;
            existeProveedor.Provincia = objProveedor.Provincia == null ? string.Empty : objProveedor.Provincia;

            return existeProveedor;
        }

        public static Usuario ValidarUsuario(UsuarioReq objUsuario, Usuario existeUsuario)
        {
            existeUsuario.UserName = objUsuario.UserName == null ? string.Empty : objUsuario.UserName;
            existeUsuario.Password = objUsuario.Password == null ? string.Empty : objUsuario.Password;
            existeUsuario.Email = objUsuario.Email == null ? string.Empty : objUsuario.Email;
            existeUsuario.IdTipoUsuario = objUsuario.IdTipoUsuario == null ? 0 : objUsuario.IdTipoUsuario;

            return existeUsuario;
        }
    }
}
