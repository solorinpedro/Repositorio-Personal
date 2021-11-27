using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinalProyect.DAL;
using FinalProyect.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.BLL
{
    public class CondominiosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Condominios.Any(e => e.CondominioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Condominios condominios)
        {
            if (!Existe(condominios.CondominioId))
            {
                return Insertar(condominios);
            }
            else
            {
                return Modificar(condominios);
            }
        }

        private static bool Insertar(Condominios condominios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Condominios.Add(condominios);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }
        public static float BuscarDevuelta(int id)
        {
            var contexto = new Contexto();
            var devuelta = new Condominios();

            try
            {
                devuelta = contexto.Condominios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return devuelta.Devolucion;
        }

        public static bool Modificar(Condominios condominios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(condominios).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var condominios = contexto.Condominios.Find(id);

                if (condominios != null)
                {
                    contexto.Condominios.Remove(condominios);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Condominios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Condominios condominios;

            try
            {
                condominios = contexto.Condominios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return condominios;
        }

        public static List<Condominios> GetList(Expression<Func<Condominios, bool>> criterio)
        {
            List<Condominios> lista = new List<Condominios>();
            Contexto contexto = new Contexto();
            try
            {

                lista = contexto.Condominios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Condominios> GetList()
        {
            List<Condominios> lista = new List<Condominios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Condominios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
