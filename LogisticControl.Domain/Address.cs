using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Address
{
    public Address() { }
    public Address(int id, string street, int number, string? complement, string neighborhood, string city, StateEnum state, int companyId)
    {
        this.Id = id;
        this.Street = street;
        this.Number = number;
        this.Complement = complement;
        this.Neighborhood = neighborhood;
        this.City = city;
        this.State = state;
        this.CompanyId = companyId;
    }

    public int Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public StateEnum State { get; set; }
    public virtual int CompanyId { get; set; } // Chave estrangeira
    public virtual Company Company { get; set; } // Propriedade de navegação
}