using FastEndpoints;
using FastEndpoints2.Entities;
using FastEndpoints2.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FastEndpoints2.Features.Users.Register;

public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<Models.Request, Models.Response>
{
    public override void Configure()
    {
        Post("/api/users/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.Request req, CancellationToken ct)
    {
        UserModel newUser = UserModel.Create(req.username, req.password, req.email, req.firstName, req.lastName, req.birthDate);

        _dbContext.Users.Add(newUser);

        await _dbContext.SaveChangesAsync(ct);

        await SendAsync(new Models.Response(newUser));
    }
}
