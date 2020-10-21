using System;
using System.ComponentModel.DataAnnotations;

namespace DROrdenes.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }

        public String Nombres { get; set; }
    }
}