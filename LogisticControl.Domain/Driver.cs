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

    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<Route>? Routes { get; set; }
}