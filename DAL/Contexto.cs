using DROrdenes.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DROrdenes.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source = Data\DOrdenes.db");
        }   
    }
}