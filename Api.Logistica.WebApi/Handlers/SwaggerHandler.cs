using Api.Logistica.WebApi.Const;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api.Logistica.WebApi.Handlers
{
    public static class SwaggerHandler
    {
        public static void SwaggerConfig(IServiceCollection service)
        {
            service.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc(SwaggerConfigConst.DocInfoVersion, new OpenApiInfo
                {
                    Title = SwaggerConfigConst.DocInfoTitle,
                    Version = SwaggerConfigConst.DocInfoVersion
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name.Replace("Framework","WebApi")}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                sw.IncludeXmlComments(xmlPath);
            });
        }

        public static void userSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint(SwaggerConfigConst.EndPointUrl, SwaggerConfigConst.EndPointDescription);
            });
        }
    }
}
