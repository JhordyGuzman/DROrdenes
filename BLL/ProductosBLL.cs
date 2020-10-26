using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DROrdenes.Entidades;
using DROrdenes.DAL;
using System.Collections.Generic;


namespace DROrdenes.BLL
{
    public class ProductosBLL
    {
        

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio){
            
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try{
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Productos.Where(criterio).ToList();

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return lista;
        }
    }
}