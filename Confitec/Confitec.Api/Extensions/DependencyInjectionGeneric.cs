using Confitec.Domain.Mapping;
using Confitec.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.API.Extensions
{
	public static class DependencyInjectionGeneric
	{
		public static IServiceCollection AddDIAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}


		public static IServiceCollection AddDIContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ConfitecContext>(
			options => options.UseSqlServer(configuration["ConnectionStrings:ConfitecDB"]));

			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
        public static IServiceCollection AddDICORS(this IServiceCollection services)
        {
            // include support for CORS
            // More often than not, we will want to specify that our API accepts requests coming from other origins (other domains). When issuing AJAX requests, browsers make preflights to check if a server accepts requests from the domain hosting the web app. If the response for these preflights don't contain at least the Access-Control-Allow-Origin header specifying that accepts requests from the original domain, browsers won't proceed with the real requests (to improve security).
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy-public",
                    builder => builder.WithOrigins("http://localhost:4200",
                                                   "https://localhost")   //WithOrigins and define a specific origin to be allowed (e.g. https://mydomain.com)
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            return services;
        }

    }
}
