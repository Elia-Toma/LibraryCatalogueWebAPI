using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Repositories;

namespace Paradigmi.Enterprise.Models.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MyDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
			});

			services.AddScoped<UtenteRepository>();
			services.AddScoped<LibroRepository>();
			services.AddScoped<CategoriaRepository>();

			return services;
		}
	}
}
