using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DROrdenes.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Decimal Monto { get; set; }

        [ForeignKey("VentaId")]

         public virtual List<VentasDetalle> Detalle { get; set; } = new List<VentasDetalle>();

    }
}