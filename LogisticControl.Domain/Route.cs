using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Route
{
    public Route() { }
    public Route(int id, DateTime opening, DateTime? realization, DateTime? finalization, int? driver_Id, StatusRouteEnum status, string? observation)
    {
        Id = id;
        Opening = opening;
        Realization = realization;
        Finalization = finalization;
        Driver_Id = driver_Id;
        Status = status;
        Observation = observation;
    }

    public int Id { get; private set; }
    public DateTime Opening { get; private set; }
    public DateTime? Realization { get; private set; }
    public DateTime? Finalization { get; private set; }
    public int? Driver_Id { get; private set; }
    public Driver? Driver { get; private set; }
    public StatusRouteEnum Status { get; private set; }
    public string? Observation { get; private set; }
    public List<Service> Services { get; private set; }
}