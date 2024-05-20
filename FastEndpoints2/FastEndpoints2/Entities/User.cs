using Microsoft.Extensions.Diagnostics.HealthChecks;
using YamlDotNet.Serialization;

namespace FastEndpoints2.Entities;

public class UserModel
{
    private Guid Id { get; set; }
    private string Username { get; set; }
    private string Password { get; set; }
    private string Email { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private DateOnly BirthDate { get; set; }
    private string Nation { get; set; }
    private string City { get; set; }
    private string Address { get; set; }

    private UserModel(Guid id, string username, string password, string email, string firstName, string lastName, DateOnly birthDate, string nation, string city, string address)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Nation = nation;
        City = city;
        Address = address;
    }

    public static UserModel Create(string username, string password, string email, string firstName, string lastName, DateOnly birthDate)
    {
        return new UserModel(new Guid(), username, password, email, firstName, lastName, birthDate, string.Empty, string.Empty, string.Empty);
    }

}

