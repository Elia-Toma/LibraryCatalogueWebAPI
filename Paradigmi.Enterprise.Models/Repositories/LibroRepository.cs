using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Repositories
{
	public class LibroRepository : GenericRepository<Libro>
	{
		public LibroRepository(MyDbContext ctx) : base(ctx)
		{
		}

		public void CreateLibro(Libro libro, ICollection<string> nomiCategorie)
		{
			if (nomiCategorie != null)
			{
				foreach (var nomeCategoria in nomiCategorie)
				{
					libro.Categorie.Add(new LibroCategoria
					{
						Categoria = _ctx.Categorie.First(c => c.Nome == nomeCategoria)
					});
				}
			}

			Aggiungi(libro);
		}

		public void DeleteLibro(int id)
		{
			DeleteCategorieAssociateAlLibro(id);
			Elimina(id);
		}

		private void DeleteCategorieAssociateAlLibro(int id)
		{
			_ctx.LibriCategorie.RemoveRange(_ctx.LibriCategorie.Where(lc => lc.IdLibro == id));
		}

		public Libro GetLibroDaNome(string nome)
		{
			return _ctx.Libri.First(l => l.Nome == nome);
		}

		public List<Libro> GetLibriDaAutore(int from, int num, string? autore, out int totalNum)
		{
			var query = _ctx.Libri.AsQueryable();
			if (!string.IsNullOrEmpty(autore))
			{
				query = query.Where(l => l.Autore.ToLower().Contains(autore.ToLower()));
			}

			totalNum = query.Count();

			return
				query
				.OrderBy(o => o.Autore)
				.Skip(from)
				.Take(num)
				.ToList();
		}

		public List<Libro> GetLibriDaCategoria(int from, int num, string? categoria, out int totalNum)
		{
			var idCategoria = _ctx.Categorie.First(c => c.Nome == categoria).IdCategoria;
			var idLibri = _ctx.LibriCategorie.Where(lc => lc.IdCategoria == idCategoria).Select(lc => lc.IdLibro).ToList();

			var query = _ctx.Libri.AsQueryable();
			if (!string.IsNullOrEmpty(categoria))
			{
				query = query.Where(l => idLibri.Contains(l.IdLibro));
			}

			totalNum = query.Count();

			return
				query
				.OrderBy(o => o.Autore)
				.Skip(from)
				.Take(num)
				.ToList();
		}

		public List<Libro> GetLibriDaDataPubblicazione(int from, int num, DateTime? data, out int totalNum)
		{
			var query = _ctx.Libri.AsQueryable();
			if (data.HasValue)
			{
				query = query.Where(l => l.DataPubblicazione == data);
			}

			totalNum = query.Count();

			return
				query
				.OrderBy(o => o.DataPubblicazione)
				.Skip(from)
				.Take(num)
				.ToList();
		}

		public void UpdateLibro(int id, Libro libro)
		{
			var libroDaAggiornare = _ctx.Libri.Find(id);
			libroDaAggiornare.Nome = libro.Nome;
			libroDaAggiornare.Autore = libro.Autore;
			libroDaAggiornare.DataPubblicazione = libro.DataPubblicazione;
			libroDaAggiornare.Editore = libro.Editore;

			Modifica(libroDaAggiornare);
		}
	}
}
