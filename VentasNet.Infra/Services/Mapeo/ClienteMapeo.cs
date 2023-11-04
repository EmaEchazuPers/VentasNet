using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ClienteMapeo
    {
        public static Cliente clienteModelo(ClienteReq objCliente)
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

    }
}
