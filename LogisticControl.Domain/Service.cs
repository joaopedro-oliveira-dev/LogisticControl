using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Service
{
    public int ID { get; set; }
    public required ServiceType ServiceType { get; set; }
    public Priority? Priority { get; set; }
    public TrackingType? TrackingType { get; set; }
    public string? Tracking { get; set; }
    public string? Observation { get; set; }
    public required StatusItem StatusItem { get; set; }
    public string? Responsible { get; set; }
    public string? DriverObservation { get; set; }
    public required StatusService Status { get; set; }
}