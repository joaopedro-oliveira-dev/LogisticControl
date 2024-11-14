using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Service
{
    public int Id { get; private set; }
    public ServiceTypeEnum ServiceType { get; private set; }
    public int? Adress_Id { get; private set; }
    public Address? Adress {  get; private set; }
    public PriorityEnum? Priority { get; private set; }
    public TrackingTypeEnum? TrackingType { get; private set; }
    public string? Tracking { get; private set; }
    public string? Observation { get; private set; }
    public StatusItemEnum StatusItem { get; private set; }
    public string? Responsible { get; private set; }
    public string? DriverObservation { get; private set; }
    public StatusServiceEnum Status { get; private set; }
    public int? Route_Id { get; private set; }
    public Route? Route { get; private set; }
}