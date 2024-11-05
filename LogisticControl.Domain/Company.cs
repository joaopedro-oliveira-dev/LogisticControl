using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Company
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public PartnershipTypeEnum PartnershipType { get; private set;}
    public string Phone { get; private set; }
    public List<Adress> Adresses { get; private set; } // Propriedade de coleção
}