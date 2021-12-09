using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect.Entidades
{
    public class TipoCondominios
    {
        [Key]
        public int TipoCondominioId { get; set; }
        public string Tipo { get; set; }
    }
}
