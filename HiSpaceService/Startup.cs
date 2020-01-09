using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HiSpaceService.Models;
using HiSpaceService.CustomException;
using Microsoft.EntityFrameworkCore.Migrations;
using WebActivatorEx;
using HiSpaceService.Handlers;
//using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;


//using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(HiSpaceService.SwaggerConfig), "Register")]

namespace HiSpaceService
{
    //public class SwaggerConfig
    //{
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
            services.AddDbContext<HiSpaceContext>(opt => opt.UseSqlServer(Configuration["ConnectionString:HiSpaceDB"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            //var thisAssembly = typeof(SwaggerConfig).Assembly;
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.SwaggerDoc("v1", new Info { Description = "My API", Title = "My API", Version = "v1" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.xml");
                c.IncludeXmlComments(filePath);
            });
            

            //services.AddCors(CorsHandler);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            //var swaggerOptions = new HiSpaceService.Options.SwaggerOptions();
            //Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            //app.UseSwagger(option => 
            //option.RouteTemplate = swaggerOptions.JsonRoute
            //    );        
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseCors();
            

            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseHttpsRedirection();
            //loggerFactory.AddLog4Net();
            app.UseMvc();

            //app.UseIdentity();
            //app.UseAuthentication();
        }
    }
    //}
}
