using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItemManagement.Infrastructure.Extensions.EfCore
{
    public static class Extension
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration["CONNECTION_STRING"]))
                ;

            return services;
        }
    }
}