using FluentValidation;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Services;

namespace Paradigmi.Enterprise.Application.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddValidatorsFromAssembly(
	AppDomain.CurrentDomain.GetAssemblies().
		SingleOrDefault(assembly => assembly.GetName().Name == "Paradigmi.Enterprise.Application")
	);

			services.AddScoped<IUtenteService, UtenteService>();
			services.AddScoped<ILibroService, LibroService>();
			services.AddScoped<ICategoriaService, CategoriaService>();
			services.AddScoped<ITokenService, TokenService>();

			return services;
		}
	}
}
