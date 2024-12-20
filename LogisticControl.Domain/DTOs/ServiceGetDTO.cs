using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;

namespace LogisticControl.Domain.DTOs;

public class ServiceGetDTO
{
    public int Id { get; set; }
    public string ServiceType { get; set; }
    public int? AddressId { get; set; }
    public virtual Address? Address { get; set; }
    public string? Priority { get; set; }
    public string? TrackingType { get; set; }
    public string? Tracking { get; set; }
    public string? Observation { get; set; }
    public string StatusItem { get; set; }
    public string? Responsible { get; set; }
    public string? DriverObservation { get; set; }
    public string Status { get; set; }
    public int? RouteId { get; set; }
}