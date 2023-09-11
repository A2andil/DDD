using A5bark.Application;
using A5bark.Application.Dispatchers;
using A5bark.Core.Repositories;
using A5bark.Infrastructure.Contexts;
using A5bark.Infrastructure.Dispatchers;
using A5bark.Infrastructure.Exceptions.Definition;
using A5bark.Infrastructure.Logging;
using A5bark.Infrastructure.Persistence.Postgres;
using A5bark.Infrastructure.Persistence.Postgres.Repositories;
using A5bark.Infrastructure.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace A5bark.Infrastructure
{
    public static class Extensions
    {
        private const string CorrelationIdKey = "correlation-id";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddErrorHandling();
            services.AddContext();
            services.AddSwaggerDocs();
            services.AddPostgres();

            services.AddSingleton(services.GetOptions<AppSettings>("app"));
            services.AddSingleton<IDispatcher, Dispatcher>();

            services.AddTransient<IOrdersRepository, OrdersRepository>();

            return services;
        }


        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseCorrelationId();

            app.UseErrorHandling();

            app.UseSwaggerDocs();

            app.UseHttpsRedirection();

            app.UseContext();

            app.UseLogging();

            app.UseRouting();

            app.UseAuthorization();

            return app;
        }

        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
            where TModel : new()
        {
            if (!string.IsNullOrWhiteSpace(sectionName))
            {
                var model = new TModel();
                configuration.GetSection(sectionName).Bind(model);

                return model;
            }

            return default(TModel);
        }

        public static TModel GetOptions<TModel>(this IServiceCollection services, string sectionName)
            where TModel : new()
        {
            if (!string.IsNullOrWhiteSpace(sectionName))
            {
                using var serviceProvider = services.BuildServiceProvider();
                var configuration = serviceProvider.GetService<IConfiguration>();
                return configuration.GetOptions<TModel>(sectionName);
            }

            return default(TModel);
        }

        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
            => app.Use((ctx, next) =>
            {
                ctx.Items.Add(CorrelationIdKey, Guid.NewGuid());
                return next();
            });

        public static Guid? TryGetCorrelationId(this HttpContext context)
            => context.Items.TryGetValue(CorrelationIdKey, out var id) ? (Guid)id : null;

        public static string GetUserIpAddress(this HttpContext context)
        {
            if (context is null)
            {
                return string.Empty;
            }

            var ipAddress = context.Connection.RemoteIpAddress?.ToString();

            if (context.Request.Headers.TryGetValue("x-forwarded-for", out var forwardedFor))
            {
                var ipAddresses = forwardedFor.ToString().Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (ipAddresses.Any())
                {
                    ipAddress = ipAddresses[0];
                }
            }

            return ipAddress ?? string.Empty;
        }
    }
}
