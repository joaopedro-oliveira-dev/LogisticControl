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

    public int Id { get; private set; }
    public string Name { get; private set; }
    public PartnershipTypeEnum PartnershipType { get; private set;}
    public string Phone { get; private set; }
    public List<Address> Adresses { get; private set; } // Propriedade de coleção
}