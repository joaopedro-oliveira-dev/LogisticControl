using FluentValidation;
using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.Validators;

public class LoginValidator : AbstractValidator<LoginDTO>
{
    public LoginValidator()
    {
        RuleFor(l => l.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório.");

        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Senha é obrigatória.");
    }
}