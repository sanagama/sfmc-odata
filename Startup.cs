using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.UriParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Create and use a local Sqlite DB for this demo
            services.AddDbContext<SfmcContext>(options =>
            {
                options.UseSqlite("Data Source=./Data/SfmcDemo.db");
            });

            // Add API versioning
            services.AddApiVersioning(o => {
                    o.ReportApiVersions = true;
                    //o.AssumeDefaultVersionWhenUnspecified = true;
                    //o.DefaultApiVersion = new ApiVersion(2, 0);
                });

            // Add OData middleware
            services.AddOData();
            services.AddTransient<SfmcOdataModelBuilder>();
            services.AddSingleton(sp => new ODataUriResolver() { EnableCaseInsensitive = true });

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SfmcOdataModelBuilder modelBuilder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Map OData routes to the EDM models discovered by convention.
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("ODataRoutes", null, modelBuilder.GetEdmModel(app.ApplicationServices));

                // See: https://github.com/t03apt/AspNetCoreOdataTest/blob/96612ae5fd5fba5f3d38c8378f7dca62e7e59373/AspNetCoreOdataTest/Startup.cs#L54
                routeBuilder.EnableDependencyInjection(containerBuilder =>
                    containerBuilder.AddService<ODataUriResolver>(
                        Microsoft.OData.ServiceLifetime.Singleton,
                        _ => app.ApplicationServices.GetRequiredService<ODataUriResolver>()));
            });
        }
    }
}