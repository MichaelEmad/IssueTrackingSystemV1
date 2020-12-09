using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Infra.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracking.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("IssueTrackingConnection"));
            });
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
