using FluentValidation;
using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.Validators;

public class RoutePostValidator : AbstractValidator<RoutePostDTO>
{
    public RoutePostValidator()
    {
        RuleFor(r => r.Observation)
            .MaximumLength(150).WithMessage("Observação deve conter no máximo 150 caracteres.");
    }
}