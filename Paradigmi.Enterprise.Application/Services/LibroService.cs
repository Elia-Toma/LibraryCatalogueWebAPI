using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Models.Repositories;

namespace Paradigmi.Enterprise.Application.Services
{
	public class LibroService : ILibroService
	{
		private readonly LibroRepository _libroRepository;

		public LibroService(LibroRepository libroRepository)
		{
			_libroRepository = libroRepository;
		}

		public void DeleteLibro(int id)
		{
			_libroRepository.DeleteLibro(id);
			_libroRepository.Save();
		}
	}
}
