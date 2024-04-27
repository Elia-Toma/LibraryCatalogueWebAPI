using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Models.Entities;
using Paradigmi.Enterprise.Models.Repositories;

namespace Paradigmi.Enterprise.Application.Services
{
	public class CategoriaService : ICategoriaService
	{
		private readonly CategoriaRepository _categoriaRepository;

		public CategoriaService(CategoriaRepository categoriaRepository)
		{
			_categoriaRepository = categoriaRepository;
		}

		public void CreateCategoria(Categoria categoria)
		{
			_categoriaRepository.CreateCategoria(categoria);
			_categoriaRepository.Save();
		}

		public void DeleteCategoriaVuota(int id)
		{
			_categoriaRepository.DeleteCategoriaVuota(id);
			_categoriaRepository.Save();
		}
	}
}
