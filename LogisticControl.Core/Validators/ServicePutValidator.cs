using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;

namespace LogisticControl.Core.Validators;

public class ServicePutValidator : AbstractValidator<ServicePutDTO>
{
    public ServicePutValidator()
    {
        RuleFor(s => s.ServiceType)
            .NotEmpty().WithMessage("Tipo de serviço é obrigatório.");
        RuleFor(s => s.ServiceType)
            .Must(serviceType => Enum.IsDefined(typeof(ServiceTypeEnum), serviceType))
            .WithMessage("Tipo de serviço inválido.")
            .When(s => s.ServiceType != null & s.ServiceType != String.Empty);

        RuleFor(s => s.Priority)
            .Must(priority => Enum.IsDefined(typeof(PriorityEnum), priority))
            .WithMessage("Prioridade inválida.")
            .When(s => s.Priority != null & s.Priority != String.Empty);

        RuleFor(s => s.TrackingType)
            .Must(trackingType => Enum.IsDefined(typeof(TrackingTypeEnum), trackingType))
            .WithMessage("Tipo de rastreio inválido.")
            .When(s => s.TrackingType != null & s.TrackingType != String.Empty);

        RuleFor(s => s.Tracking)
            .NotEmpty().When(s => s.TrackingType != null)
            .WithMessage("Rastreio é obrigatório quando o tipo de rastreio é selecionado.");
        RuleFor(s => s.Tracking)
            .Matches(@"^[\d/-]+$").When(s => s.TrackingType != TrackingTypeEnum.Descricao.ToString())
            .WithMessage("Rastreio inválido para tipo selecionado.");

        RuleFor(s => s.Observation)
            .MaximumLength(150).WithMessage("Observação deve conter no máximo 150 caracteres.");

        RuleFor(s => s.StatusItem)
            .NotEmpty().WithMessage("Status do(s) item(ns) é(são) obrigatório(s).");
        RuleFor(s => s.StatusItem)
            .Must(statusItem => Enum.IsDefined(typeof(StatusItemEnum), statusItem))
            .WithMessage("Status do(s) item(ns) inválido(s)")
            .When(s => s.StatusItem != null & s.StatusItem != String.Empty);

        RuleFor(s => s.Responsible)
            .Length(3, 50).WithMessage("Nome do responsável deve conter entre 3 e 50 caracteres.");

        RuleFor(s => s.DriverObservation)
            .MaximumLength(150).WithMessage("Observação do motorista deve conter no máximo 150 caracteres.");

        RuleFor(s => s.Status)
            .NotEmpty().WithMessage("Status do serviço é obrigatório.");
        RuleFor(s => s.Status)
            .Must(status => Enum.IsDefined(typeof(StatusServiceEnum), status))
            .WithMessage("Status do serviço inválido.")
            .When(s => s.Status != null & s.Status != String.Empty);

        RuleFor(s => s.RouteId)
            .NotEmpty().WithMessage("Id da rota é obrigatório quando o serviço não está pendente.")
            .When(s => s.Status != StatusServiceEnum.Pendente.ToString() & s.Status != null & s.Status != String.Empty);
    }
}