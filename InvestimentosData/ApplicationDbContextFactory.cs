using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oracle.EntityFrameworkCore; 

namespace InvestimentosData
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseOracle(
                "User Id=RM550187;Password=311003;Data Source=oracle.fiap.com.br:1521/ORCL;"
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
