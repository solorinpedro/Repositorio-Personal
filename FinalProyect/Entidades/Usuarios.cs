using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProyect.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [ForeignKey("RolId")]
        public Roles Roles { get; set; }
        public int RolId { get; set; }
    }
}