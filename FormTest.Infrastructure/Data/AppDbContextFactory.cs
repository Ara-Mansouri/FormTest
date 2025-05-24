using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace FormTest.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Use the same connection string here as in appsettings.json
            optionsBuilder.UseSqlServer("Server=localhost;Database=BrandingCompony;User Id=sa;Password=mansouri;TrustServerCertificate=true;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

