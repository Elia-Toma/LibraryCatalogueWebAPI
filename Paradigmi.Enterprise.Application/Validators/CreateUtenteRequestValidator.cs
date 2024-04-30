using FluentValidation;
using Paradigmi.Enterprise.Application.Extensions;
using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Validators
{
	public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
	{
		public CreateUtenteRequestValidator()
		{
			RuleFor(x => x.Email)
				.NotNull()
				.WithMessage("Il campo Email è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Email è obbligatorio (vuoto)")
				.MinimumLength(5)
				.WithMessage("Il campo Email deve essere lungo almeno 5 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Email deve essere lungo al massimo 50 caratteri")
				.EmailAddress()
				.WithMessage("Il campo Email non è un indirizzo email valido");

			RuleFor(x => x.Nome)
				.NotNull()
				.WithMessage("Il campo Nome è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Nome è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Nome deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Nome deve essere lungo al massimo 50 caratteri");

			RuleFor(x => x.Cognome)
				.NotNull()
				.WithMessage("Il campo Cognome è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Cognome è obbligatorio (vuoto)")
				.MinimumLength(2)
				.WithMessage("Il campo Cognome deve essere lungo almeno 2 caratteri")
				.MaximumLength(50)
				.WithMessage("Il campo Cognome deve essere lungo al massimo 50 caratteri");

			RuleFor(x => x.Password)
				.NotNull()
				.WithMessage("Il campo Password è obbligatorio (nullo)")
				.NotEmpty()
				.WithMessage("Il campo Password è obbligatorio (vuoto)")
				.MinimumLength(6)
				.WithMessage("Il campo Password deve essere lungo almeno 6 caratteri")
				.RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
				, "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
				);
		}
	}
}
