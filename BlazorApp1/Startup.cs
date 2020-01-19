using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp1.Data;
using BlazorApp1.Entities;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using BlazorApp1.Models;

namespace BlazorApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();  // enable ASP.NET Core Web API
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<DemoDbContext>(options =>
            {
                if (Env.IsDevelopment())
                {
                    options.UseSqlite("Data Source=app.db");
                }
                else
                {
                    // options.UseSqlServer("...")
                }
            }, ServiceLifetime.Transient);

            //services.AddTransient<IValidator<EmployeeCreateForm>, EmployeeCreateFormValidator>();
            services.AddValidatorsFromAssemblyContaining<Program>();

            services.AddAuthentication("cookie").AddCookie("cookie", options =>
            {
                options.LoginPath = "/login";
                options.LoginPath = "/logout";
                options.LoginPath = "/access-denied";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Env.IsDevelopment())
            {
                using var scope = app.ApplicationServices.CreateScope();
                scope.ServiceProvider.GetRequiredService<DemoDbContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();      // Enable ASP.NET Core Web API
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
