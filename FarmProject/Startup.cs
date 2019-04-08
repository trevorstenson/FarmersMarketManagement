using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProject.Models;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace FarmProject
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
            services.AddCors();

            services.AddDbContext<FarmersdbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("AzureConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Farmer's Market API", Version = "v1" });
            });

            services.AddProblemDetails();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            /*
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/dist";
            });
            */
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseSpaStaticFiles();
            app.UseStaticFiles();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseProblemDetails();
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    "Spa",
                    new {controller = "Home", action = "Spa"});
            });


            /*
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client";
            });
            */
        }
    }
}
