using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogisticControl.Domain;

public class Driver
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
}