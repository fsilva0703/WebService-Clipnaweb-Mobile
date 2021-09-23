using AlterDataVotador.Domain.ViewModel.Entity;
using AlterDataVotador.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AlterDataVotador.Infra.Data.Context
{
    public class AlterDataContext : DbContext
    {
        public DbSet<Setor> Tb_Setor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=79.143.185.213;Database=AlterDataVotador;User Id=sa;Password=x#DEV@70c9b;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Setor>(new SetorMap().Configure);
        }
    }
}
