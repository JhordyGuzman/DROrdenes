using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DROrdenes.Entidades;
using DROrdenes.DAL;
using System.Collections.Generic;

namespace DROrdenes.BLL
{
    public class OrdenesBLL
    {

        //Boton Guardar//
        public static bool Guardar(Ordenes ordenes){
           if(!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
           else
                return Modificar(ordenes);
        }
        
        private static bool Insertar(Ordenes ordenes){

             bool paso = false;
             Contexto contexto = new Contexto();

            try{
                //Agregar a la entidad que se desea ingresar al contexto
                contexto.Ordenes.Add(ordenes);
                var orden = contexto.Ordenes.Find(ordenes.OrdenId);
                
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

        private static bool Modificar(Ordenes ordenes){

            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Marcar la entidad como modificada para que 
                //el contexto sepa como proceder
                contexto.Entry(ordenes).State= EntityState.Modified;
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
                var ordenes = contexto.Ordenes.Find(id);

                if(ordenes != null){
                    contexto.Ordenes.Remove(ordenes);//Removemos la entidad
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

        public static Ordenes Buscar(int id){

            Contexto contexto = new Contexto();
            Ordenes ordenes = new Ordenes();

            try{
                ordenes =contexto.Ordenes.Find(id);

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return ordenes;

        }

        public static bool Existe(int id){

            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Ordenes.Any(e => e.OrdenId ==id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try{
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Ordenes.Where(criterio).ToList();

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