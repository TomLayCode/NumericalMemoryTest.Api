using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using MediatR;
using NumericalMemoryTest.Application.Commands;
using NumericalMemoryTest.Domain.Abstractions;
using NumericalMemoryTest.Infrastructure.Services;
using NumericalMemoryTest.Infrastructure.Configuration;
using Microsoft.AspNetCore.Hosting;
using NumericalMemoryTest.Persistence;
using NumericalMemoryTest.Persistence.Abstractions;
using NumericalMemoryTest.Persistence.Queries;

namespace NumericalMemoryTest
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

            services.AddControllersWithViews();
            services.AddMediatR(typeof(Startup), typeof(GetNumberCommand), typeof(SaveResultCommand));
            services.Add(new ServiceDescriptor(typeof(NumericalMemoryContext), new NumericalMemoryContext(Configuration.GetConnectionString("DefaultConnection"))));

            services.AddSingleton<IGenerateNumbersService, GenerateNumbersService>();
            services.AddSingleton<IGetDataQuery, GetDataQuery>();
            services.AddSingleton<ISaveDataQuery, AddDataQuery>();
            services.AddSingleton<Settings>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
