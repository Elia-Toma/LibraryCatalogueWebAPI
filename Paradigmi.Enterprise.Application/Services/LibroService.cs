using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Models.Entities;
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

		public void CreateLibro(Libro libro)
		{
			_libroRepository.Aggiungi(libro);
			_libroRepository.Save();
		}

		public void DeleteLibro(int id)
		{
			_libroRepository.DeleteLibro(id);
			_libroRepository.Save();
		}

		public void UpdateLibro(Libro libro)
		{
			_libroRepository.Modifica(libro);
			_libroRepository.Save();
		}
	}
}
