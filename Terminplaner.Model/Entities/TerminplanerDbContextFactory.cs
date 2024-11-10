using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace Terminplaner.Model.Entities {
    /// <summary>
    /// factory class to create an instance of TerminplanerContext during desing time
    /// used by entity framework for generatiuong migrations and uipdating the database
    /// </summary>
    public class TerminplanerDbContextFactory : IDesignTimeDbContextFactory<TerminplanerDbContext>
    {
        public TerminplanerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TerminplanerDbContext>();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            return new TerminplanerDbContext(optionsBuilder.Options);
        }
    }
}
