using Confitec.Entity.Repository;
using Confitec.Entity.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.API.Extensions
{
	public static class DependencyInjectionRepository
	{
		public static IServiceCollection AddDIRepository(this IServiceCollection services)
		{
			services.AddTransient<IUsuarioRepository, UsuarioRepository>();

			return services;
		}
	}
}
