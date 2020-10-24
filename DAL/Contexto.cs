using System;
using System.Collections.Generic;
using System.Text;
using DROrdenes.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DROrdenes.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }

        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"Data Source = Data\DOrdenes.db");
        }

                 protected override void OnModelCreating(ModelBuilder modelBuilder)
                 {
                    modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 1, Costo = 70, Descripcion = "Pan", Inventario = 150 });
                    modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 2, Costo = 20, Descripcion = "Jugos Ya", Inventario= 230 });
                    modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 3, Costo = 50, Descripcion = "Coca Cola", Inventario = 110 });
                    modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 4, Costo = 42, Descripcion = "Chocolate Cortes", Inventario= 197 });
                    modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 5, Costo = 317, Descripcion = "Arroz Campo", Inventario = 215 });

                    modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 1, Nombres = "Yoma" });
                    modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 2, Nombres = "Nesttle" });
                    modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 3, Nombres = "La Sirena" });
                    modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 4, Nombres = "Porvenir" });
                    modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 5, Nombres = "Palmares" });
           
                }   
    }
}