using FinalProyect.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Condominios> Condominios { get; set; }
        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<TipoCondominios> TipoCondominios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Proyecto.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles {
                RolId = 1,
                Descripcion = "Admin"
            });

            modelBuilder.Entity<Usuarios>().HasData(new Usuarios {
                UsuarioId = 1,
                Nombre = "Pedro",
                Apellido = "Solorin",
                NombreUsuario = "Admin",
                Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                //1234
                FechaCreacion = DateTime.Now,
                RolId = 1
            });
            modelBuilder.Entity<TipoCondominios>().HasData(new TipoCondominios {
                TipoCondominioId = 1,
                Tipo = "Apartamento"

            });
            modelBuilder.Entity<TipoCondominios>().HasData(new TipoCondominios {
                TipoCondominioId = 2,
                Tipo = "Parqueo"

            });
        }
    }
}
