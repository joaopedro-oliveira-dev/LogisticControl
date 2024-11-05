using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogisticControl.Domain;

public class Driver
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public List<Route>? Routes { get; private set; }
}