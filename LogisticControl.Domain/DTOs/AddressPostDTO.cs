using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.DTOs;

public class AddressPostDTO
{
    public string Street { get; set; }
    public int Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int CompanyId { get; set; }
}