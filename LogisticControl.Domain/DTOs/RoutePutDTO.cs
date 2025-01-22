namespace LogisticControl.Domain.DTOs;

public class RoutePutDTO
{
    public DateTime? Realization { get; set; }
    public DateTime? Finalization { get; set; }
    public int? DriverId { get; set; }
    public string Status { get; set; }
    public string? Observation { get; set; }
}