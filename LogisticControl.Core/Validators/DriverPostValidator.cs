using FluentValidation;
using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.Validators;

public class DriverPostValidator : AbstractValidator<DriverPostDTO>
{
    public DriverPostValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .Length(3, 50).WithMessage("Nome deve conter entre 3 e 50 caracteres.");

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
            .WithMessage("Número de celular inválido. Use o formato (XX) 9XXXX-XXXX.");
    }
}