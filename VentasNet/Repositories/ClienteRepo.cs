using VentasNet.Models;

namespace VentasNet.Repositories
{
    public class ClienteRepo
    {
        public bool AgregarCliente() 
        {
            return false;
        }

        public void ModificarCliente(Cliente cli)
        {
            int index = Listados.ListaCliente.FindIndex(x => x.Id == cli.Id);
            if (index != -1) 
            {
                Listados.ListaCliente[index].Cuit = cli.Cuit;
                Listados.ListaCliente[index].RazonSocial = cli.RazonSocial;
                Listados.ListaCliente[index].Domicilio = cli.Domicilio;
                Listados.ListaCliente[index].Provincia = cli.Provincia;
            }
            
        }

        public bool VerificarCliente(Cliente cli)
        {
            bool existe = false;
            Cliente existeCliente = new Cliente();

            existeCliente = Listados.ListaCliente.Find(x=>x.Id == cli.Id);

            if (existeCliente != null) 
            {
                existe = true;
            }

            return existe;
        }

        internal void EliminarCliente(int id)
        {
            int index = Listados.ListaCliente.FindIndex(x => x.Id == id);
            Listados.ListaCliente[index].Estado = false;
        }
    }
}
