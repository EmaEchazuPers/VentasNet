﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Entity.Models
{
    public partial class MovimientoDeComprobantes
    {
        public int Id { get; set; }
        public int IdComprobante { get; set; }
        public int? IdMovimientoProveedor { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Total { get; set; }
    }
}