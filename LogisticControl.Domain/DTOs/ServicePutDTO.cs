using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;

namespace LogisticControl.Domain.DTOs;

public class ServicePutDTO
{
    public ServiceTypeEnum ServiceType { get; set; }
    public int? AddressId { get; set; }
    public PriorityEnum? Priority { get; set; }
    public TrackingTypeEnum? TrackingType { get; set; }
    public string? Tracking { get; set; }
    public string? Observation { get; set; }
    public StatusItemEnum StatusItem { get; set; }
    public string? Responsible { get; set; }
    public string? DriverObservation { get; set; }
    public StatusServiceEnum Status { get; set; }
    public int? RouteId { get; set; }
}