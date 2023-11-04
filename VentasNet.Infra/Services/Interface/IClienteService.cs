﻿using VentasNet.Entity.Models;

namespace VentasNet.Infra.Services.Interface
{
    public interface IClienteService
    {
        public void CrearNuevoCliente(Cliente cliente);
        public void ModificarCliente(Cliente cliente);
        public void EliminarCliente(int id);


    }
}
