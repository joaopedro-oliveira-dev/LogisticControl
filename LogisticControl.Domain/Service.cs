using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Service
{
    public Service() { }
    public Service(int id, ServiceTypeEnum serviceType, int? adress_Id, PriorityEnum? priority, TrackingTypeEnum? trackingType, string? tracking, 
        string? observation, StatusItemEnum statusItem, string? responsible, string? driverObservation, StatusServiceEnum status, int? route_Id)
    {
        Id = id;
        ServiceType = serviceType;
        Adress_Id = adress_Id;
        Priority = priority;
        TrackingType = trackingType;
        Tracking = tracking;
        Observation = observation;
        StatusItem = statusItem;
        Responsible = responsible;
        DriverObservation = driverObservation;
        Status = status;
        Route_Id = route_Id;
    }

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