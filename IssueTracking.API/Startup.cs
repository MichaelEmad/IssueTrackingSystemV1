using System.Reflection;
using IssueTracking.API.Services;
using IssueTracking.Application;
using IssueTracking.Application.Interfaces;
using IssueTracking.Domain.Interfaces;
using IssueTracking.Infra;
using IssueTracking.Infra.Persistence;
using IssueTracking.Infra.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IssueTracking.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddInfraDependencyInjection(_configuration);
            services.AddApplicationDI();
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(
                swagger=> swagger.SwaggerDoc("v1",new OpenApiInfo{Title = "IssueTracking",Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/swagger/v1/swagger.json","IssueTrackingV1"));
            app.UseCors(
                cors => cors
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
