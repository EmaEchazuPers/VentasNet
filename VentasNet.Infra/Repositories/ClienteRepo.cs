using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Services.Interface;
using VentasNet.Infra.Services.Mapeo;

namespace VentasNet.Infra.Repositories
{
    public class ClienteRepo : IClienteRepo
    {
        private readonly VentasNetContext _context;

        private readonly IClienteService _clienteService;
        public ClienteRepo(VentasNetContext context, IClienteService clienteService) 
        {
            _context = context;
            _clienteService = clienteService;
        }

        public ClienteResponse AddCliente(ClienteReq objCliente) 
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            if(objCliente.Cuit != null)
            {
                var existeCliente = GetClienteCuit(objCliente.Cuit);

                if (existeCliente == null)
                {
                    try
                    {
                        var clienteNew = ClienteMapeo.clienteModelo(objCliente);
                        clienteNew.Estado = true;
                        clienteNew.FechaAlta = DateTime.Now;

                        _clienteService.CrearNuevoCliente(clienteNew);

                        
                        clienteResponse.Guardar = true;
                        clienteResponse.RazonSocial = clienteNew.RazonSocial;
                        clienteResponse.Mensaje = "Se agrego el cliente";
                        
                    }
                    catch (Exception ex)
                    {
                        //Crear un diccionario de errores
                        clienteResponse.Mensaje = "Ocurrio un error al agregar cliente";
                        clienteResponse.Guardar = false;
                    }

                }
            }

            return clienteResponse;
        }

        /*
        public Cliente MapeoCliente(ClienteReq objCliente)
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = objCliente.IdCliente,
                Cuit = objCliente.Cuit,
                RazonSocial = objCliente.RazonSocial,
                Nombre = objCliente.Nombre,
                Apellido = objCliente.Apellido,
                Domicilio = objCliente.Domicilio,
                Localidad = objCliente.Localidad,
                Provincia = objCliente.Provincia,
                Telefono = objCliente.Telefono,
                Estado = objCliente.Estado,
                FechaAlta = objCliente.FechaAlta,
                FechaBaja = objCliente.FechaBaja,
                IdUsuario = objCliente.IdUsuario
            };

            return cliente;
        }
        */

        public ClienteResponse UpdateCliente(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuit);

            if (existeCliente != null)
            {
                try
                {
                    //armar funcion para validad cliente
                    existeCliente.Cuit = objCliente.Cuit == null ? string.Empty : objCliente.Cuit;
                    existeCliente.RazonSocial = objCliente.RazonSocial == null ? string.Empty : objCliente.RazonSocial ;
                    existeCliente.Nombre = objCliente.Nombre == null ? string.Empty : objCliente.Nombre;
                    existeCliente.Apellido = objCliente.Apellido == null ? string.Empty : objCliente.Apellido;
                    existeCliente.Domicilio = objCliente.Domicilio == null ? string.Empty : objCliente.Domicilio;
                    existeCliente.Localidad = objCliente.Localidad == null ? string.Empty : objCliente.Localidad;
                    existeCliente.Provincia = objCliente.Provincia == null ? string.Empty : objCliente.Provincia;
                    existeCliente.Telefono = objCliente.Telefono == null ? string.Empty : objCliente.Telefono;

                    //existeCliente = validarCliente(objCliente, existeCliente)
                    //public Cliente ValidadCliente(ClienteReq objCliente, Cliente existeCliente) -> Formato de funcion
                    //
                    _clienteService.ModificarCliente(existeCliente);

                    //_context.Update(existeCliente); --> Esto se hace en service
                    //_context.SaveChanges();

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                    clienteResponse.Mensaje = "Se modifico el cliente";
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrio un error al modificar cliente";
                    clienteResponse.Guardar = false;
                }

            }

            return clienteResponse;
        }


        public ClienteResponse Delete(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuit);

            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Estado = false;
                    existeCliente.FechaBaja = DateTime.Now;
                    _clienteService.EliminarCliente(existeCliente.IdCliente);

                    //_context.Update(existeCliente);
                    //_context.SaveChanges();

                    clienteResponse.Guardar = true;
                    clienteResponse.Mensaje = "Se elimino el cliente";
                    
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrio un error al eliminar cliente";
                    clienteResponse.Guardar = false;
                }

            }

            return clienteResponse;
        }

        public Cliente GetClienteCuit(string cuit)
        {
            var cliente = _context.Cliente.Where(x => x.Cuit == cuit).FirstOrDefault();

            return cliente;
        }

        public List<ClienteReq> GetClientes() 
        {
            List<ClienteReq> listadoClientes = new List<ClienteReq>();

            var lista = _context.Cliente.Where(x => x.Estado != false).ToList();

            foreach ( var item in lista ) 
            {
                ClienteReq cliente = new ClienteReq();

                cliente.Nombre = item.Nombre;
                cliente.Apellido = item.Apellido;
                cliente.Cuit = item.Cuit;
                cliente.Domicilio = item.Domicilio;
                cliente.Localidad = item.Localidad;
                cliente.Provincia = item.Provincia;
                cliente.RazonSocial = item.RazonSocial;
                cliente.Telefono = item.Telefono;
                cliente.Estado = item.Estado;
                cliente.FechaAlta = cliente.FechaAlta;
                cliente.FechaBaja = item.FechaBaja;

                listadoClientes.Add(cliente);
            }
            return listadoClientes;
        }
        
    }
}
