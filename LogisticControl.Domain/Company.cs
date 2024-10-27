using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Company
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required PartnershipType PartnershipType { get; set;}
    public required string Phone { get; set; }
}