using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect.Entidades
{
    public class ClientesDetalle
    {
        [Key]
        public int ClientesDetalleId { get; set; }
        public int ClienteId { get; set; }
        public int CondominioId { get; set; }

        [ForeignKey("CondominioId")]
        public Condominios Condominios { get; set; }
        public Clientes Clientes { get; set; }
    }
}
