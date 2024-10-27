using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Adress
{
    public int ID { get; set; }
    public required string Street { get; set; }
    public required int Number { get; set; }
    public string? Complement { get; set; }
    public required string Neighborhood { get; set; }
    public required string City { get; set; }
    public required State State { get; set; }
}