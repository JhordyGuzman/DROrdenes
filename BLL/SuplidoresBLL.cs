using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DROrdenes.Entidades;
using DROrdenes.DAL;
using System.Collections.Generic;


namespace DROrdenes.BLL
{
    public class SuplidoresBLL
    {
        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio){
            
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try{
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Suplidores.Where(criterio).ToList();

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