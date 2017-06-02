using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.OData.Builder;

namespace oData
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddOData();
            //services.AddScoped<IPeopleService, PeoplesController>();
            //services.AddScoped<ITripsService, TripsController>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var provider = app.ApplicationServices.GetRequiredService<IAssemblyProvider>();
            app.UseMvc(builder => builder.MapODataRoute("odata", GetEdmModel(provider)));
        }
        
        private static IEdmModel GetEdmModel(IAssemblyProvider assemblyProvider)
        {
            var builder = new ODataConventionModelBuilder(assemblyProvider);
            builder.EntitySet<Person>("Peoples");
            builder.EntityType<Person>().HasKey(x => x.ID);
            builder.EntitySet<Trip>("Trips");
            builder.EntityType<Trip>().HasKey(x => x.ID);
            return builder.GetEdmModel();
        }
    }

}
