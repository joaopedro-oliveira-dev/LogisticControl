using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.Models;

public class Address
{
    public Address() { }
    public Address(int id, string street, int number, string? complement, string neighborhood, string city, StateEnum state, int companyId)
    {
        Id = id;
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        CompanyId = companyId;
    }

    public int Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public StateEnum State { get; set; }
    public int CompanyId { get; set; } // Chave estrangeira
    public virtual Company Company { get; set; } // Propriedade de navegação
    public virtual ICollection<Service> Services { get; set; }
}