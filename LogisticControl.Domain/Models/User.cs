using LogisticControl.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticControl.Domain.Models;

public class User
{
    public User()
    {
    }
    public User(string id, string name, string email, string password, RoleEnum role, bool active)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        Active = active;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
    public bool Active { get; set; }
}