using Microsoft.Extensions.DependencyInjection;
using ItemManagement.Application.Services;
using ItemManagement.Application.Interfaces.Services;
using ItemManagement.Domain.Models;
using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Infrastructure.Repositories;

namespace ItemManagement.Infrastructure.DependencyContainer
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IDictionaryStringIdRepository<Role>, DictionaryStringIdRepository<Role>>();
            services.AddScoped<IDictionaryRepository<Color>, DictionaryRepository<Color>>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IAccessSettingsRepository, AccessSettingsRepository>();


            // Services
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}