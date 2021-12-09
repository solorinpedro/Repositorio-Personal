using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinalProyect.DAL;
using FinalProyect.Entidades;

namespace FinalProyect.BLL
{
    public class TipoCondominiosBLL
    {
        public static List<TipoCondominios> GetList(Expression<Func<TipoCondominios, bool>> criterio)
        {
            List<TipoCondominios> lista = new List<TipoCondominios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoCondominios.Where(criterio).ToList();
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
