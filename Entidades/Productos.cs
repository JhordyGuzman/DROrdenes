using System;
using System.ComponentModel.DataAnnotations;

namespace DROrdenes.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        public String Descripcion { get; set; }

        public Decimal Costo { get; set; }

        public double Inventario { get; set; }
    }
}