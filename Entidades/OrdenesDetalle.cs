using System;
using System.ComponentModel.DataAnnotations;

namespace DROrdenes.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }

        public int OrdenId { get; set; }

        public float Cantidad { get; set; }

        public Decimal Costo { get; set; }



        public OrdenesDetalle(int ordenId, float cantidad, Decimal costo)
        {
            OrdenId = ordenId;
            Cantidad = cantidad;
            Costo = costo;
        }
    }
}