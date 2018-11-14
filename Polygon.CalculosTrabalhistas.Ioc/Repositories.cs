using Microsoft.Extensions.DependencyInjection;
using Polygon.CalculosTrabalhistas.Domain.Repositories;
using Polygon.CalculosTrabalhistas.Repositories.Mongo;
using Polygon.CalculosTrabalhistas.Repositories.Raven;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Ioc
{
    public static class Repositories
    {
        public static void AddIocRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICalculoRepository, CalculoRepository>();
            services.AddTransient<IPeriodoPericulosidadeRepository, PeriodoPericulosidadeRepository>();
        }
    }
}
