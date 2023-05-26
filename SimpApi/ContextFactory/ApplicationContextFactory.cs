using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SimpApi.DataAccess.Context;

namespace SimApi.ContextFactory
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            //configuration
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            //DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj => prj.MigrationsAssembly("SimpApi.DataAccess"));

            return new ApplicationContext(builder.Options);

        }
    }
}
