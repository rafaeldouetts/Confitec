using Confitec.Domain.Services;
using Confitec.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.API.Extensions
{
	public static class DependencyInjectionService
	{
		public static IServiceCollection AddDIService(this IServiceCollection services)
		{
			services.AddTransient<IUsuarioService, UsuarioService>();

			return services;
		}
	}
}
