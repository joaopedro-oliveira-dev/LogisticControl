using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.Models;

public class Company
{
    public Company() { }
    public Company(int id, string name, PartnershipTypeEnum partnershipType, string phone)
    {
        Id = id;
        Name = name;
        PartnershipType = partnershipType;
        Phone = phone;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public PartnershipTypeEnum PartnershipType { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } // Propriedade de coleção
}