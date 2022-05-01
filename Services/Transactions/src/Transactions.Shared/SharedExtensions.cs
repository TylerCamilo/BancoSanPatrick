using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Application.Interfaces;
using Transactions.Shared.Services;

namespace Transactions.Shared
{
    public static class SharedExtensions
    {
        public static void AddSharedInfraestructureExtensions(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
