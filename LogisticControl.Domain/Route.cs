using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Route
{
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