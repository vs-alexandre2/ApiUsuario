using Microsoft.EntityFrameworkCore;
using ApiTarefa.ApiTarefa.Domain.Models;

namespace ApiTarefa.ApiTarefa.Infrastructure.DataContexts
{
    public class TarefaDbContext : DbContext
    {
       
        public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TarefaModel>().ToTable("Tarefa");
        }
    }
}
