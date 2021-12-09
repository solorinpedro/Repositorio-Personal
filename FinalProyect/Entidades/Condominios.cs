using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public float Costo { get; set; }
        [ForeignKey("TipoCondominiosId")]
        public int TipoCondominiosId { get; set; }
        public virtual TipoCondominios TipoCondominios { get; set; }

        public Condominios()
        {
            CondominioId = 0;
        }
    }
}
