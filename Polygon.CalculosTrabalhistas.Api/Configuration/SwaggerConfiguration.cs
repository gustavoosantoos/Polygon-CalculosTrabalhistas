using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polygon.CalculosTrabalhistas.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        private const string DOCS_VERSION = "v1.0.0";
        private const string DOCS_TITLE = "Polygon Cálculos Trabalhistas";

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(DOCS_VERSION, new Info { Title = DOCS_TITLE, Version = DOCS_VERSION });
            });
        }

        public static void ConfigSwagger(this IApplicationBuilder builder)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{DOCS_VERSION}/swagger.json", DOCS_TITLE);
            });
        }
    }
}
