using System.Reflection;
using MediatR;
using FluentValidation;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Services;
using IssueTracking.Domain.Interfaces;
using IssueTracking.Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IMapperService,MapperService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
