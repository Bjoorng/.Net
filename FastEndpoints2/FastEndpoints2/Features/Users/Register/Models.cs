using FastEndpoints2.Entities;

namespace FastEndpoints2.Features.Users.Register;

public class Models
{
    public record Request(string username, string password, string email, string firstName, string lastName, DateOnly birthDate);
    public record Response(UserModel user);
}
