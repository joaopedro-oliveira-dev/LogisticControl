using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;

namespace LogisticControl.Core.Validators;

public class CompanyPostValidator : AbstractValidator<CompanyPostDTO>
{
    public CompanyPostValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .Length(2, 50).WithMessage("Nome deve conter entre 2 a 50 caracteres.");

        RuleFor(c => c.PartnershipType)
            .NotEmpty().WithMessage("Tipo de parceria é obrigatório.");
        RuleFor(c => c.PartnershipType)
            .Must(partnershipType => Enum.IsDefined(typeof(PartnershipTypeEnum), partnershipType))
            .WithMessage("Tipo de parceria não é válido.")
            .When(c => c.PartnershipType != null & c.PartnershipType != String.Empty);

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Matches(@"^\(\d{2}\) \d{4,5}-\d{4}$")
            .WithMessage("Número de telefone inválido. Use o formato (XX) XXXXX-XXXX ou (XX) XXXX-XXXX.");
    }
}