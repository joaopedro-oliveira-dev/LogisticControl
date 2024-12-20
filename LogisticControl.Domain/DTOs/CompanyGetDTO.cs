using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.DTOs;

public class CompanyGetDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PartnershipType { get; set; }
    public string Phone { get; set; }
}