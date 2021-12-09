using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect.Entidades
{
    public class Recibos
    {
        [Key]
        public int ReciboId { get; set; }

        [ForeignKey("CondominioId")]
        public int CondominioId { get; set; }
        public virtual Condominios Condominios { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}
