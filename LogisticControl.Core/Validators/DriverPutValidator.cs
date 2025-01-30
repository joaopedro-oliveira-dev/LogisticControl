using FluentValidation;
using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.Validators;

public class DriverPutValidator : AbstractValidator<DriverPutDTO>
{
    public DriverPutValidator()
    {
        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
            .WithMessage("Número de celular inválido. Use o formato (XX) 9XXXX-XXXX.");
    }
}