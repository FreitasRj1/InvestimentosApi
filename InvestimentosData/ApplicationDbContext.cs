using InvestimentosModel;
using Microsoft.EntityFrameworkCore;

namespace InvestimentosData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Investimento> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do campo Valor para Oracle (por exemplo, NUMBER(18,2))
            modelBuilder.Entity<Investimento>()
                .Property(i => i.Valor)
                .HasPrecision(18, 2);
        }
    }
}
