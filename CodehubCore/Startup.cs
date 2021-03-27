using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodehubCore
{
    public class Startup
    {
        // MUA: Constructor to the startup class [Already exist].
        public Startup(IConfiguration configuration) // MUA: [Already exist] "Constructor Injection".
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            //// MUA: Access custom setting from "appsettings.json".
            //app.Run(async (context) =>
            //{
            //    await context.Response
            //    .WriteAsync(Configuration["MuaKey"]);
            //});

            // MUA: Fine the name of the process
            //app.Run(async (context) =>
            //{
            //    await context.Response
            //    .WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //});

            app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync("I am learning .Net Core");
            });


            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
