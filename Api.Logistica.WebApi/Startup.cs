using Api.Logistica.Data.Context;
using Api.Logistica.WebApi.Const;
using Api.Logistica.WebApi.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logistica.WebApi
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
            services.AddDbContext<LogisticaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMemoryCache();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    p => p
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4200")
                        );
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDistributedMemoryCache();

            services.AddHttpClient("SsslPolicy");

            SwaggerHandler.SwaggerConfig(services);
            DependencyInjectionHandler.DependencyInjectionConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SwaggerHandler.userSwagger(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();               
                app.UseSwagger();
                app.UseSwaggerUI(sw =>
                {
                    sw.SwaggerEndpoint(SwaggerConfigConst.EndPointUrl, SwaggerConfigConst.EndPointDescription);
                });
                
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
