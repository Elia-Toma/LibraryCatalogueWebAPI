using FluentValidation;
using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Validators
{
    public class GetLibriDaAutoreRequestValidator : AbstractValidator<GetLibriDaAutoreRequest>
	{
		public GetLibriDaAutoreRequestValidator()
		{
			RuleFor(x => x.PageSize)
				.GreaterThan(0)
				.WithMessage("Il campo PageSize deve essere maggiore di 0")
				.LessThanOrEqualTo(100)
				.WithMessage("Il campo PageSize deve essere minore o uguale a 100");

			RuleFor(x => x.PageNumber)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Il campo PageNumber deve essere maggiore o uguale a 0");

			RuleFor(x => x.Autore)
				.NotNull()
				.WithMessage("Il campo Autore è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Autore è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Autore deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Autore deve essere lungo al massimo 50 caratteri");
		}

	}
}
