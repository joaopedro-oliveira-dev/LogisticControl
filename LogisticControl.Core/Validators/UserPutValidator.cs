using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;

namespace LogisticControl.Core.Validators;

public class UserPutValidator : AbstractValidator<UserPutDTO>
{
    public UserPutValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail não é válido.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
            .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d.*\d.*\d)(?=.*[!@#$%^&*(),.?':{}|<>]).+$")
            .WithMessage("A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, três números e um caractere especial.");

        RuleFor(u => u.Role)
        .NotEmpty().WithMessage("O cargo é obrigatório.");
        RuleFor(u => u.Role)
        .Must(role => Enum.IsDefined(typeof(RoleEnum), role))
        .WithMessage("O cargo não é válido.")
        .When(u => u.Role != null & u.Role != String.Empty);
    }
}