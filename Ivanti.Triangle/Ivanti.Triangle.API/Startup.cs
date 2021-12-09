using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ivanti.Triangle.Domain.Calculators.GridReferenceCalculators;
using Ivanti.Triangle.Domain.Calculators.TriangleCalculators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Ivanti.Triangle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddMvc();
        //    services.AddScoped<TriangleByGridReferenceCalculator>();
        //    services.AddScoped<ITriangleCalculatorFactory, TriangleCalculatorFactory>();

        //    services.AddScoped<GridReferenceByTriangleCalculator>();

        //    services.AddSwaggerGen();

        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("_myAllowSpecificOrigins",
        //            builder =>
        //            {
        //                builder.WithOrigins("https://localhost:53914").AllowAnyHeader().AllowAnyMethod();
        //            });
        //    });

        //    //services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
        //    //    .AllowAnyMethod()
        //    //    .AllowAnyHeader()));

        //    //services.AddCors(options =>
        //    //{
        //    //    options.AddPolicy("CorsPolicy",
        //    //        builder => builder.AllowAnyOrigin()
        //    //            .AllowAnyMethod()
        //    //            .AllowAnyHeader());
        //    //});

        //    //services.AddCors(opt =>
        //    //{
        //    //    opt.AddDefaultPolicy(builder =>
        //    //    {
        //    //        builder.AllowAnyOrigin()
        //    //            .AllowAnyHeader()
        //    //            .AllowAnyMethod();
        //    //    });
        //    //});

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseRouting();

        //    app.UseCors("_myAllowSpecificOrigins");

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });

        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ivanti triangle API");
        //    });

        //}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<TriangleByGridReferenceCalculator>();
            services.AddScoped<ITriangleCalculatorFactory, TriangleCalculatorFactory>();

            services.AddScoped<GridReferenceByTriangleCalculator>();

            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44343").AllowAnyHeader().AllowAnyMethod();
                    });
            });

        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("_myAllowSpecificOrigins");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ivanti triangle API");
            });
        }
    }
}
