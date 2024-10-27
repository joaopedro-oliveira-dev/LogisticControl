using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Route
{
    public int ID { get; set; }
    public required DateTime Opening { get; set; }
    public DateTime? Realization { get; set; }
    public DateTime? Finalization { get; set; }
    public required StatusRoute Status { get; set; }
    public string? Observation { get; set; }
}