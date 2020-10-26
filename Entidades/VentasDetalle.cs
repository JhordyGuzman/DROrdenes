using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DROrdenes.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }

        public int VentaId { get; set; }

        public string Servicio { get; set; }

        public Decimal Precio { get; set; }
    }
}