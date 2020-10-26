using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DROrdenes.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Decimal Monto { get; set; }

        [ForeignKey ("OrdenId") ]
        public virtual List<OrdenesDetalle> Detalle { get; set; } = new List<OrdenesDetalle>();

        
        [ForeignKey("SuplidorId")]
        public Suplidores suplidores { get; set; }

    }
}