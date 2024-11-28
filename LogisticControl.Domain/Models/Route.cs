using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.Models;

public class Route
{
    public Route() { }
    public Route(int id, DateTime opening, DateTime? realization, DateTime? finalization, int? driverId, StatusRouteEnum status, string? observation)
    {
        Id = id;
        Opening = opening;
        Realization = realization;
        Finalization = finalization;
        DriverId = driverId;
        Status = status;
        Observation = observation;
    }

    public int Id { get; set; }
    public DateTime Opening { get; set; }
    public DateTime? Realization { get; set; }
    public DateTime? Finalization { get; set; }
    public int? DriverId { get; set; }
    public virtual Driver? Driver { get; set; }
    public StatusRouteEnum Status { get; set; }
    public string? Observation { get; set; }
    public virtual ICollection<Service> Services { get; set; }
}