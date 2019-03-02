using System;
using Cozy.Data.Context;
using Cozy.Data.Implementation.EFCore;
using Cozy.Data.Implementation.Mock;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Web.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Repository Layer injection

            GetDependencyResolvedForEFCoreRepositoryLayer(services);

            //Service Layer injection
            GetDependencyResolvedForServiceLayer(services);

            services.AddDbContext<CozyDbContext>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<CozyDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Signin"; //overrides the default naming convention (Originally /Account/Login)
                options.AccessDeniedPath = "/Account/Unauthorized";
            });

            services.Configure<IdentityOptions>(options =>
               {
                  options.Password.RequireDigit = true;
                  options.Password.RequireLowercase = true;
                  options.Password.RequireNonAlphanumeric = false;
                  options.Password.RequireUppercase = false;
                  options.Password.RequiredLength = 6;
                  options.Password.RequiredUniqueChars = 1;
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseAuthentication(); //Makes use of Identity

            app.UseMvcWithDefaultRoute();
            //Controller/view/?id
            //Default Controller: HomeController
            //Default View: Index
            //Home/Index/id

        }

        private void GetDependencyResolvedForEFCoreRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeRepository, EFCoreHomeRepository>();
            services.AddScoped<ILeaseRepository, EFCoreLeaseRepository>();
            services.AddScoped<IMaintenanceRepository, EFCoreMaintenanceRepository>();
            services.AddScoped<IMaintenanceStatusRepository, EFCoreMaintenanceStatusRepository>();
            services.AddScoped<IPaymentRepository, EFCorePaymentRepository>();
        }

        private void GetDependencyResolvedForServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ILeaseService, LeaseService>();
        }
    }
}
