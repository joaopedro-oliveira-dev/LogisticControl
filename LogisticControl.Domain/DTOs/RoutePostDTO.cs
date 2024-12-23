using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.DTOs;

public class RoutePostDTO
{
    public DateTime? Realization { get; set; }
    public DateTime? Finalization { get; set; }
    public int? DriverId { get; set; }
    public string? Observation { get; set; }
}