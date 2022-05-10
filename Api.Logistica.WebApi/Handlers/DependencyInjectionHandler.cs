using Api.Logistica.Application.Services;
using Api.Logistica.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logistica.WebApi.Handlers
{
    public static class DependencyInjectionHandler
    {
        public static void DependencyInjectionConfig(IServiceCollection services)
        {
            services.AddTransient<IPedidoService, PedidoServices>();
        }

    }
}
