using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect.Entidades
{
    public class Condominios
    {
        [Key]
        public int CondominioId { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public float Efectivo { get; set; }
        public float Devolucion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
