using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;

namespace LogisticControl.Core.Validators;

public class AddressPutValidator : AbstractValidator<AddressPutDTO>
{
    public AddressPutValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Logradouro é obrigatório.");

        RuleFor(a => a.Number)
            .NotEmpty().WithMessage("Número é obrigatório.");

        RuleFor(a => a.Neighborhood)
            .NotEmpty().WithMessage("Bairro é obrigatório.");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("Cidade é obrigatória.");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("Estado é obrigatório.")
            .MaximumLength(2).WithMessage("Estado deve ser abreviado.");
        RuleFor(a => a.State)
            .Must(state => Enum.IsDefined(typeof(StateEnum), state))
            .WithMessage("Estado não é válido.")
            .When(a => a.State != null & a.State != String.Empty);
    }
}