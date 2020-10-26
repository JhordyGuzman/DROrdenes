using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DROrdenes.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }

        public int OrdenId { get; set; }

        public int ProductoId { get; set; }

        public double Cantidad { get; set; }

        public int SuplidorId { get; set; }

         [ForeignKey("ProductoId")]

        public Productos productos {get; set;} = new Productos();
    }
}