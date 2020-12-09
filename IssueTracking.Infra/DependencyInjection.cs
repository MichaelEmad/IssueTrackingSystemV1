using IssueTracking.Infra.Identity;
using IssueTracking.Infra.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracking.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraDI(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(option =>
            //{
            //    option.UseSqlServer(configuration.GetConnectionString("IssueTrackingConnection"));
            //});

            return services;
        }

    }
}
