using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace A5bark.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }

        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
            => builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddQueryHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher()
                .AddInMemoryQueryDispatcher();
        public static string ToSnakeCase(this string input)
            => Regex.Replace(
                Regex.Replace(
                    Regex.Replace(input, @"([\p{Lu}]+)([\p{Lu}][\p{Ll}])", "$1_$2"), @"([\p{Ll}\d])([\p{Lu}])", "$1_$2"), @"[-\s]", "_").ToLower();
    }
}
