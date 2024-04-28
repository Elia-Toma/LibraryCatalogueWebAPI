using FluentValidation;
using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Validators
{
	public class UpdateLibroRequestValidator : AbstractValidator<UpdateLibroRequest>
	{
		public UpdateLibroRequestValidator()
		{
			RuleFor(x => x.IdLibro)
				.NotNull()
				.WithMessage("Il campo IdLibro è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo IdLibro è obbligatorio (vuoto)")
				.GreaterThan(0)
				.WithMessage("Il campo IdLibro deve essere maggiore di 0");

			RuleFor(x => x.Nome)
				.NotNull()
				.WithMessage("Il campo Nome è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Nome è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Nome deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Nome deve essere lungo al massimo 50 caratteri");

			RuleFor(x => x.Autore)
				.NotNull()
				.WithMessage("Il campo Autore è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Autore è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Autore deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Autore deve essere lungo al massimo 50 caratteri");

			RuleFor(x => x.DataPubblicazione)
				.NotNull()
				.WithMessage("Il campo DataPubblicazione è obbligatorio (nullo)");

			RuleFor(x => x.Editore)
				.NotNull()
				.WithMessage("Il campo Editore è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Editore è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Editore deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Editore deve essere lungo al massimo 50 caratteri");
		}
	}
}
