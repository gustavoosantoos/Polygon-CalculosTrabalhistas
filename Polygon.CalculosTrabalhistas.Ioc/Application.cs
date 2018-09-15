using Microsoft.Extensions.DependencyInjection;
using Polygon.CalculosTrabalhistas.Application.Interface;
using Polygon.CalculosTrabalhistas.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Ioc
{
    public static class Application
    {
        public static void AddIocApplication(this IServiceCollection services)
        {
            services.AddTransient<ICalculoService, CalculoService>();
        }
    }
}
