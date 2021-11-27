using FinalProyect.DAL;
using FinalProyect.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect.BLL
{
    public class ClientesBLL
    {
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Clientes.Any(e => e.ClienteId == id);
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

        public static bool Insertar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Clientes.Add(clientes);

                foreach (var detalle in clientes.Detalles)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.Condominios).State = EntityState.Modified;
                }

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

        public static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var ClienteAnterior = contexto.Clientes
                     .Where(x => x.ClienteId == clientes.ClienteId)
                     .Include(x => x.Detalles)
                     .ThenInclude(x => x.Condominios)
                     .AsNoTracking()
                     .SingleOrDefault();

                contexto.Database.ExecuteSqlRaw($"Delete FROM ClientesDetalle where ClienteId={clientes.ClienteId}");

                foreach (var item in clientes.Detalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    contexto.Entry(item.Condominios).State = EntityState.Modified;
                }
                contexto.Entry(clientes).State = EntityState.Modified;
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

        public static bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
                return Insertar(clientes);
            else
                return Modificar(clientes);
        }

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes = new Clientes();

            try
            {
                clientes = contexto.Clientes.Include(x => x.Detalles)
                    .Where(x => x.ClienteId == id)
                    .Include(x => x.Detalles)
                    .ThenInclude(x => x.Condominios)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var cliente = contexto.Clientes.Find(id);

                foreach (var item in cliente.Detalles)
                {
                    contexto.Entry(item.Clientes).State = EntityState.Modified;
                    contexto.Entry(item.Condominios).State = EntityState.Modified;
                }


                contexto.Entry(cliente).State = EntityState.Deleted;

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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            var lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Clientes.Where(criterio).ToList();
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

        public static List<Clientes> GetClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Clientes.ToList();
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

