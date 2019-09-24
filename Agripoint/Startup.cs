using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Business.Implementations;
using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Repository;
using Data.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agripoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Services
            services.AddScoped(typeof(IServiceCrud<>), typeof(ServiceCrud<>));
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserService, UserService>();


            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Method to auto register all services to the Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyPath"></param>
        private void ConfigureServicesDI(IServiceCollection services, string assemblyPath)
        {
            //recovers the service dll
            var assembly = Assembly.LoadFrom(Path.Combine(assemblyPath, "Business.dll"));

            //find all interfaces
            var interfaceTypes = assembly.DefinedTypes.Where(x => x.IsInterface);
            //find all concrete classes
            var concreteTypes = assembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract);

            foreach (var interfaceType in interfaceTypes)
            {
                //for each interface, find the matching concrete implementation and register to the Dependency Injection
                var concreteType = concreteTypes.FirstOrDefault(x => x.ImplementedInterfaces.Contains(interfaceType));
                if (concreteType != null)
                {
                    services.AddScoped(interfaceType, concreteType);
                }
            }
        }

        /// <summary>
        /// Method to auto register all services to the Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyPath"></param>
        private void ConfigureRepositoriesDI(IServiceCollection services, string assemblyPath)
        {
            //recovers the service dll
            var assembly = Assembly.LoadFrom(Path.Combine(assemblyPath, "Data.dll"));

            //find all interfaces
            var interfaceTypes = assembly.DefinedTypes.Where(x => x.IsInterface);
            //find all concrete classes
            var concreteTypes = assembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract);

            foreach (var interfaceType in interfaceTypes)
            {
                //for each interface, find the matching concrete implementation and register to the Dependency Injection
                var concreteType = concreteTypes.FirstOrDefault(x => x.ImplementedInterfaces.Contains(interfaceType));
                if (concreteType != null)
                {
                    services.AddScoped(interfaceType, concreteType);
                }
            }
        }
    }
}
