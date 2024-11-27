using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

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
    public PartnershipTypeEnum PartnershipType { get; set;
    }
    public string Phone { get; set; }
    public virtual ICollection<Address> Adresses { get; set; } // Propriedade de coleção
}