using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BackEndApi.Data;
using BackEndApi.Data.Repositories;
using BackEndApi.Domain.Interfaces;
namespace BackEndApi.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<WoundExpertDataContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());

            //});
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddScoped<IPatientRepository, PatientRepository>();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "BackEndApi",
                    Description = "This is the backend API",
                    TermsOfService = "https://example.com/terms",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Syed Abiddin",
                        Email = string.Empty,
                        Url = "https://twitter.com/sabiddin",
                    },
                    License = new Swashbuckle.AspNetCore.Swagger.License
                    {
                        Name = "Use under KBsoft",
                        Url = "https://example.com/license",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowOrigin");
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
