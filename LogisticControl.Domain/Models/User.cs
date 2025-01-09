using LogisticControl.Domain.Enums;

namespace LogisticControl.Domain.Models;

public class User
{
    public User()
    {
    }
    public User(string userName, string password, RoleEnum role, bool active)
    {
        UserName = userName;
        Password = password;
        Role = role;
        Active = active;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
    public bool Active { get; set; }
}