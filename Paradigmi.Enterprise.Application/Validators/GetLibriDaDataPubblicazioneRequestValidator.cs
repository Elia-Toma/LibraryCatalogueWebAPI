using FluentValidation;
using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Validators
{
	public class GetLibriDaDataPubblicazioneRequestValidator : AbstractValidator<GetLibriDaDataPubblicazioneRequest>
	{
		public GetLibriDaDataPubblicazioneRequestValidator()
		{
			RuleFor(x => x.PageSize)
				.GreaterThan(0)
				.WithMessage("Il campo PageSize deve essere maggiore di 0")
				.LessThanOrEqualTo(100)
				.WithMessage("Il campo PageSize deve essere minore o uguale a 100");

			RuleFor(x => x.PageNumber)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Il campo PageNumber deve essere maggiore o uguale a 0");

			RuleFor(x => x.DataPubblicazione)
				.NotNull()
				.WithMessage("Il campo DataPubblicazione è obbligatorio (nullo)");
		}
	}
}
