using Microsoft.EntityFrameworkCore;
using ApiUsuario.ApiUsuario.Domain.Models;

namespace ApiUsuario.ApiUsuario.Infrastructure.DataContexts
{
    public class UsuarioDbContext : DbContext
    {
       
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EscolaridadeModel>().ToTable("Escolaridade");
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");
            modelBuilder.Entity<HistoricoEscolarModel>().ToTable("HistoricoEscolar");
            modelBuilder.Entity<UsuarioHistoricoEscolarModel>().ToTable("UsuarioHistoricoEscolar");
        }
    }
}
