using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polygon.CalculosTrabalhistas.Communication;
using Polygon.CalculosTrabalhistas.Communication.HorasPericulosidade;
using Polygon.CalculosTrabalhistas.Communication.Workers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Ioc
{
    public static class Workers
    {
        public static void AddIoCWorker(this IServiceCollection services)
        {
            services.AddTransient<CalculoQueueManager>();
            services.AddTransient<HorasPericulosidadeQueueManager>();
            services.AddSingleton<IHostedService, CalculoWorker>();
            services.AddSingleton<IHostedService, HorasPericulosidadeWorker>();
        }
    }
}
