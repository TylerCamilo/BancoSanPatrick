using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Application.Interfaces;
using Transactions.Persistence.Contexts;
using Transactions.Persistence.Repositories;

namespace Transactions.Persistence
{
    public static class PersistenceExtensions
    {
        public static void AddPersistenceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)

                ));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            #region
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RespositoryAsync<>));
            #endregion
        }
    }
}
