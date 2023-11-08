using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Common;
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
                        var clienteNew = ClienteMapeo.ReqAModelo(objCliente);
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


        public ClienteResponse UpdateCliente(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuit);

            if (existeCliente != null)
            {
                try
                {
                    var cliente = ValidarModelo.ValidarCliente(objCliente, existeCliente);

                    _clienteService.ModificarCliente(cliente);

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
                    _clienteService.EliminarCliente(existeCliente.IdCliente);

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
