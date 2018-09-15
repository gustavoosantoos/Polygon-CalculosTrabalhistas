using Microsoft.Extensions.DependencyInjection;
using Polygon.CalculosTrabalhistas.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polygon.CalculosTrabalhistas.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void Init(this IServiceCollection services)
        {
            services.AddIocRepositories();
            services.AddIocApplication();
            services.AddIoCWorker();
        }
    }
}
