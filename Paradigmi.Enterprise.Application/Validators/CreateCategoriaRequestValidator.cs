using FluentValidation;
using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Validators
{
	public class CreateCategoriaRequestValidator : AbstractValidator<CreateCategoriaRequest>
	{
		public CreateCategoriaRequestValidator()
		{
			RuleFor(x => x.Nome)
				.NotNull()
				.WithMessage("Il campo Nome è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Nome è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Nome deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Nome deve essere lungo al massimo 50 caratteri");
		}
	}
}
