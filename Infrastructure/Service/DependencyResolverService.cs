using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Service
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<RhDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:ServerConnection",
                x => x.MigrationsAssembly("Infrastructure")));
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<RhDbContext>>();
            using (var dbContext = new RhDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
