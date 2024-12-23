using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.DTOs;

public class CompanyPostDTO
{
    public string Name { get; set; }
    public PartnershipTypeEnum PartnershipType { get; set; }
    public string Phone { get; set; }
}