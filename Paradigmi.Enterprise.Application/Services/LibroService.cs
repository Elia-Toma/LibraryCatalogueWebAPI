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

		public List<Libro> GetLibriDaAutore(int from, int num, string? autore, out int totalNum)
		{
			return _libroRepository.GetLibriDaAutore(from, num, autore, out totalNum);
		}

		public List<Libro> GetLibriDaCategoria(int from, int num, string? categoria, out int totalNum)
		{
			return _libroRepository.GetLibriDaCategoria(from, num, categoria, out totalNum);
		}

		public List<Libro> GetLibriDaDataPubblicazione(int from, int num, DateTime? data, out int totalNum)
		{
			return _libroRepository.GetLibriDaDataPubblicazione(from, num, data, out totalNum);
		}

		public Libro GetLibroDaNome(string nome)
		{
			return _libroRepository.GetLibroDaNome(nome);
		}

		public void UpdateLibro(Libro libro)
		{
			_libroRepository.Modifica(libro);
			_libroRepository.Save();
		}
	}
}
