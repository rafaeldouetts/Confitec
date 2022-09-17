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
	public static class DependencyInjectionDb
	{
        public static IServiceCollection AddDIDbAplicacao(this IServiceCollection services, IConfiguration configuration)
        {
                services.AddDbContext<ConfitecContext>(options => options.UseSqlServer(configuration["ConnectionStrings:ConfitecDB"]));

            return services;
        }
    }
}
