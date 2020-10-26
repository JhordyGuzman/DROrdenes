using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DROrdenes.Entidades;
using DROrdenes.DAL;
using System.Collections.Generic;

namespace DROrdenes.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas ventas){
           if(!Existe(ventas.VentaId))
                return Insertar(ventas);
           else
                return Modificar(ventas);
        }
        
        private static bool Insertar(Ventas ventas){

             bool paso = false;
             Contexto contexto = new Contexto();

            try{
                //Agregar a la entidad que se desea ingresar al contexto
                contexto.Ventas.Add(ventas);
                var venta = contexto.Ventas.Find(ventas.VentaId);
                
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;

        }

        private static bool Modificar(Ventas ventas){

            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Marcar la entidad como modificada para que 
                //el contexto sepa como proceder
                contexto.Entry(ventas).State= EntityState.Modified;
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id){
            
            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Buscar La entidad que se desea eliminar
                var ventas = contexto.Ventas.Find(id);

                if(ventas != null){
                    contexto.Ventas.Remove(ventas);//Removemos la entidad
                    paso = contexto.SaveChanges() >0;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

        // public static Ventas Buscar(int id){

        //     Contexto contexto = new Contexto();
        //     Ventas ventas = new Ventas();

        //     try{
        //         ventas =contexto.Ventas.Find(id);

        //     }
        //     catch(Exception){
        //         throw;
        //     }
        //     finally{
        //         contexto.Dispose();
        //     }

        //     return ventas;

        // }

        public static bool Existe(int id){

            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Ventas.Any(e => e.VentaId ==id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try{
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Ventas.Where(criterio).ToList();

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