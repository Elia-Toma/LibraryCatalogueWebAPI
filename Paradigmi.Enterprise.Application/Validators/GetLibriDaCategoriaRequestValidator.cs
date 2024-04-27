using FluentValidation;
using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Validators
{
	public class GetLibriDaCategoriaRequestValidator : AbstractValidator<GetLibriDaCategoriaRequest>
	{
		public GetLibriDaCategoriaRequestValidator()
		{
			RuleFor(x => x.PageSize)
				.GreaterThan(0)
				.WithMessage("Il campo PageSize deve essere maggiore di 0")
				.LessThanOrEqualTo(100)
				.WithMessage("Il campo PageSize deve essere minore o uguale a 100");

			RuleFor(x => x.PageNumber)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Il campo PageNumber deve essere maggiore o uguale a 0");

			RuleFor(x => x.Categoria)
				.NotNull()
				.WithMessage("Il campo Categoria è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Categoria è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Categoria deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Categoria deve essere lungo al massimo 50 caratteri");
		}
	}
}
