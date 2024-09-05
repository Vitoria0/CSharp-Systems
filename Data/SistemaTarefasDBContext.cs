using Microsoft.EntityFrameworkCore;
using Sistemas.Data.Mappers;
using Sistemas.Models;

namespace Sistemas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {

        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            :base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios {  get; set; }
        public DbSet<TarefaModel> TarefaModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
