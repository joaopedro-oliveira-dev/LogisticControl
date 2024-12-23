namespace LogisticControl.Domain.DTOs;

public class RouteGetDTO
{
    public int Id { get; set; }
    public DateTime Opening { get; set; }
    public DateTime? Realization { get; set; }
    public DateTime? Finalization { get; set; }
    public int? DriverId { get; set; }
    public string Status { get; set; }
    public string? Observation { get; set; }
}