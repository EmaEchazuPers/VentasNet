using System.ComponentModel;

namespace VentasNet.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; } //Se agrega ? para permitir que sea nulo el campo
        public string? Cuit { get; set; }
        public string? Domicilio { get; set; }
        public string? Provincia { get; set; }
        public bool Estado { get; set; }    

    }

}
