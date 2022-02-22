using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coureservices.Data.Models;
using Microsoft.EntityFrameworkCore;
using coureservices.Data;

namespace coureservices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        private static void Adddatabase(IServiceProvider serviceProvider)
        {
            var Repo = serviceProvider.GetRequiredService<IServices>();

              Repo.AddCountry();
            Repo.AddCountryDetails();
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<IServices, Services>();
            services.AddDbContext<CoureServicesDbContext>(context => { context.UseInMemoryDatabase("TestDb"); });
           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "coureservices", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "coureservices v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Adddatabase(serviceProvider);
        }
    }
}
