using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace book_Application
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

                services.Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

                services.AddDistributedMemoryCache();

               

                services.AddSession(options =>
                {
                    options.Cookie.Name = ".AdventureWorks.Session";
                    //options.IdleTimeout = TimeSpan.FromSeconds(10);
                    options.Cookie.IsEssential = true;
                }); 
                
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            }

        
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //To use static files
            app.UseRouting();
            app.UseCookiePolicy(); //Cookies
            app.UseSession(); //Session

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{Id?}"

                );
             
            });
        }
    }
}
