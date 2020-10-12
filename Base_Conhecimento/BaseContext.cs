using Microsoft.EntityFrameworkCore;

namespace Base_Conhecimento
{
    class BaseContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<Solucao> Solucao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Base_Conhecimento;Trusted_Connection=True;");
        }
    }
}
