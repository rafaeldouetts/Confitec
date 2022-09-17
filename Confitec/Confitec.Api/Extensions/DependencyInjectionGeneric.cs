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
	}
}
