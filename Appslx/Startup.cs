using Appslx.Web.Modules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Appslx.Core.Models;
using Appslx.Repository;
using Appslx.Repository.Identity;
using Appslx.Web.Controllers;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Identity;
using ReflectionIT.Mvc.Paging;

namespace Appslx.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(5);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddPaging();
            // DataTables.AspNet registration with default options.
            services.RegisterDataTables();
            services.AddIdentity<User, UserRole>()
                .AddDefaultTokenProviders();
            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IRoleStore<UserRole>, RoleStore>();
            services.AddTransient<CurrentUser>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
            });



            //autofac
            services.AddMvc().AddControllersAsServices();
            var containerBuilder = new ContainerBuilder();
           
            containerBuilder.RegisterModule(new RepositoryModule());
            containerBuilder.RegisterModule(new ServiceModule());
            containerBuilder.RegisterModule(new EFModule());
            containerBuilder.Populate(services);
            //containerBuilder.RegisterType<HomeController>().PropertiesAutowired();

            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseAuthentication(); //penting jancuk buat login

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
