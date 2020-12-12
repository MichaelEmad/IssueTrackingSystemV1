using System;
using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Domain.Interfaces;
using IssueTracking.Infra.Persistence;
using IssueTracking.Infra.Persistence.Repositories;
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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("IssueTrackingConnection"));
            });
            services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
