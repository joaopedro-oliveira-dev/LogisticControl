using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Service
{
    public Service() { }
    public Service(int id, ServiceTypeEnum serviceType, int? adress_Id, PriorityEnum? priority, TrackingTypeEnum? trackingType, string? tracking, 
        string? observation, StatusItemEnum statusItem, string? responsible, string? driverObservation, StatusServiceEnum status, int? routeId)
    {
        Id = id;
        ServiceType = serviceType;
        AdressId = adress_Id;
        Priority = priority;
        TrackingType = trackingType;
        Tracking = tracking;
        Observation = observation;
        StatusItem = statusItem;
        Responsible = responsible;
        DriverObservation = driverObservation;
        Status = status;
        RouteId = routeId;
    }

    public int Id { get; set; }
    public ServiceTypeEnum ServiceType { get; set; }
    public int? AdressId { get; set; }
    public virtual Address? Adress {  get; set; }
    public PriorityEnum? Priority { get; set; }
    public TrackingTypeEnum? TrackingType { get; set; }
    public string? Tracking { get; set; }
    public string? Observation { get; set; }
    public StatusItemEnum StatusItem { get; set; }
    public string? Responsible { get; set; }
    public string? DriverObservation { get; set; }
    public StatusServiceEnum Status { get; set; }
    public int? RouteId { get; set; }
    public virtual Route? Route { get; set; }
}