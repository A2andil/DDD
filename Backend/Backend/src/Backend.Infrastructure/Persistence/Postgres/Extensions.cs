using Backend.Infrastructure.Persistence.EF;
using Backend.Infrastructure.Persistence.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Backend.Infrastructure.Persistence.Postgres
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services)
        {
            services.AddSingleton(services.GetOptions<PostgresSettings>("postgres"));
            services.AddEntityFrameworkNpgsql()
                    .AddEntityFrameworkInMemoryDatabase()
                    .AddDatabaseContext<BackendDbContext>();

            services.AddPostgresRepositories();

            return services;
        }

        public static IServiceCollection AddPostgresRepositories(this IServiceCollection services)
        {
            services.AddEntityFrameworkRepository<OrderModel, Guid, BackendDbContext>();

            return services;
        }

        public static IServiceCollection AddDatabaseContext<TDatabseContext>(this IServiceCollection services)
            where TDatabseContext : DbContext
        {
            var settings = services.GetOptions<PostgresSettings>("postgres");

            services.AddDbContext<TDatabseContext>(options =>
            {
                if (settings.InMemory)
                {
                    options.UseInMemoryDatabase(databaseName: settings.InMemoryDatabaseName);

                    return;
                }

                options.UseNpgsql(settings.ConnectionString);
                options.EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}
