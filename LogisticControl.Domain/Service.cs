using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Service
{
    public int ID { get; set; }
    public required ServiceTypeEnum ServiceType { get; set; }
    public PriorityEnum? Priority { get; set; }
    public TrackingTypeEnum? TrackingType { get; set; }
    public string? Tracking { get; set; }
    public string? Observation { get; set; }
    public required StatusItemEnum StatusItem { get; set; }
    public string? Responsible { get; set; }
    public string? DriverObservation { get; set; }
    public required StatusServiceEnum Status { get; set; }
}