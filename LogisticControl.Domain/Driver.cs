using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogisticControl.Domain;

public class Driver
{
    public Driver() { }
    public Driver(int id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public List<Route>? Routes { get; private set; }
}