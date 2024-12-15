using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.DTOs;

public class ServicePostDTO
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
}