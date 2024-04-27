using Paradigmi.Enterprise.Application.Abstractions.Services;
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

		public void CreateCategoria(string nome)
		{
			_categoriaRepository.CreateCategoria(nome);
			_categoriaRepository.Save();
		}
	}
}
