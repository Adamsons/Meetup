using MeetupTest.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace MeetupTest.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSqlPersistence();
            return services;
        }
    }
}
