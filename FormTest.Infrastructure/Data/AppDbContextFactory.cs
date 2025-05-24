using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace FormTest.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();


            optionsBuilder.UseSqlServer("Server=server-sql;Database=university;User Id=sap;Password=6983;TrustServerCertificate=true;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

