using FluentValidation;

namespace Application.UseCases.AccountCases.Registration;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
	public RegistrationRequestValidator()
	{
		RuleFor(r => r.Name).NotEmpty().MinimumLength(2).MaximumLength(200);
        RuleFor(r => r.Email).NotEmpty().EmailAddress().MinimumLength(2).MaximumLength(200);
        RuleFor(r => r.Password).NotEmpty().MinimumLength(2).MaximumLength(32); // TODO: Implementar validacao correta de senha
        RuleFor(r => r.Description).MaximumLength(200);
    }
}
