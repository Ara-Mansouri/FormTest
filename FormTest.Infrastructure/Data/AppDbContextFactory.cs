using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace FormTest.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=BrandingCompony;User Id=sa;Password=mansouri;TrustServerCertificate=true;MultipleActiveResultSets=true;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

