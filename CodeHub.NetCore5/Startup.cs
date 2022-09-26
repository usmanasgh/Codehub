using CodeHub.NetCore5.DAL;
using CodeHub.NetCore5.Interface;
using CodeHub.NetCore5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CodeHub.NetCore5.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CodeHub.NetCore5
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            var MUATEST = this.configuration["usmanasgh"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();

            //services.AddMvc(); // MUA: Adding this service to run MVC 1.1

            //services.AddMvcCore();

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>(); // 


            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            services.AddIdentity<CustomIdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            // MUA : Register dependency injection
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddSingleton<IEmployeeRepository, EmployeeMockRepository>();
            //services.AddSingleton<IEmployeeRepository, EmployeeRepository>();


            services.AddControllersWithViews();

            // MUA : Setup service to receive response in xml
            //services.AddMvc().AddXmlSerializerFormatters();

            // MUA : Adding authorize filter for entire application
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // MUA : Does this service works as a middleware ?

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //MUA: 1nd middleware code? - 1.0
            if (env.IsDevelopment() || env.IsEnvironment("MUACustom"))
            {
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                //{
                //    SourceCodeLineCount = 10 // MUA: Number of lines to display before and after the lines causes the exception
                //};

                //app.UseDeveloperExceptionPage(developerExceptionPageOptions);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseStatusCodePages();

                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
        

            //MUA: 2nd middleware code? - 1.1
            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("First middleware");
            //    //logger.LogInformation("MW1: Incoming request");  // MW1 = MiddleWare 1
            //    await next();
            //    //logger.LogInformation("MW1: Outgoing request"); 
            //});

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("First middleware");
            //    logger.LogInformation("MW2: Incoming request");  // MW2 = MiddleWare 2
            //    await next();
            //    logger.LogInformation("MW2: Outgoing request");
            //});

            // - 1.1


            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("codehub.html");

            //app.UseFileServer(fileServerOptions);

            //app.UseFileServer(); // Will call default.html


            //app.UseHttpsRedirection();

            app.UseStaticFiles(); // MUA : Adding new middleware request processing pipeline.

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            
            //app.Run(async (context) =>
            //{
            //    //throw new Exception("Custom exception");
            //    await context.Response.WriteAsync("Hosting environment : " + env.EnvironmentName);

            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
