﻿namespace VentasNet.Infra.DTO.Request
{
    public class UsuarioReq
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
        public int? IdTipoUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}
