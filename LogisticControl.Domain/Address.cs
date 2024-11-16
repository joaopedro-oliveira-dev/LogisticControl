using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain;

public class Address
{
    public Address() { }
    public Address(int id, string street, int number, string? complement, string neighborhood, string city, StateEnum state, int company_Id)
    {
        this.Id = id;
        this.Street = street;
        this.Number = number;
        this.Complement = complement;
        this.Neighborhood = neighborhood;
        this.City = city;
        this.State = state;
        this.Company_Id = company_Id;
    }

    public int Id { get; private set; }
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string? Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public StateEnum State { get; private set; }
    public int Company_Id { get; private set; } // Chave estrangeira
    public Company Company { get; private set; } // Propriedade de navegação
}