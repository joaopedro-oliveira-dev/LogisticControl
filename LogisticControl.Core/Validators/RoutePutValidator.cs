using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using Microsoft.AspNetCore.HttpLogging;

namespace LogisticControl.Core.Validators;

public class RoutePutValidator : AbstractValidator<RoutePutDTO>
{
    public RoutePutValidator()
    {
        RuleFor(r => r.Status)
            .NotEmpty().WithMessage("Status é obrigatório.")
            .Must(status => Enum.IsDefined(typeof(StatusRouteEnum), status))
            .WithMessage("Status não é válido.")
            .When(r => r.Status != null & r.Status != String.Empty);

        RuleFor(r => r.Observation)
            .MaximumLength(150).WithMessage("Observação deve conter no máximo 150 caracteres.");
    }
}