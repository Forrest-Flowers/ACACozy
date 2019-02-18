using System;
using Cozy.Data.Implementation.EFCore;
using Cozy.Data.Implementation.Mock;
using Cozy.Data.Interfaces;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            GetDependencyResolvedForRepositoryLayer(services);

            //Service Layer injection
            GetDependencyResolvedForServiceLayer(services);


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

            app.UseMvcWithDefaultRoute();
            //Controller/view/?id
            //Default Controller: HomeController
            //Default View: Index
            //Home/Index/id
        }

        private void GetDependencyResolvedForRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeRepository, MockHomeRepository>();
            services.AddScoped<ILeaseRepository, MockLeaseRepository>();
        }

        private void GetDependencyResolvedForServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ILeaseService, LeaseService>();
        }
    }
}
