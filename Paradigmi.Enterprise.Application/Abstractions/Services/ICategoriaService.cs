using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Abstractions.Services
{
	public interface ICategoriaService
	{
		void CreateCategoria(Categoria categoria);
		void DeleteCategoriaVuota(int id);
	}
}
