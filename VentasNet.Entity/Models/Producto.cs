﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Entity.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Importe { get; set; }
    }
}