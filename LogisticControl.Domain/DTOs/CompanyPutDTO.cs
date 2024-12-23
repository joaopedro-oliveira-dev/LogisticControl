using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.DTOs;

public class CompanyPutDTO
{
    public string Name { get; set; }
    public PartnershipTypeEnum PartnershipType { get; set; }
    public string Phone { get; set; }
}