namespace Author.Signup;

class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/author/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var author = Map.ToEntity(r);

        var emailIsTaken = await Data.EmailAddressIsTaken(author.Email);

        if (emailIsTaken) AddError(r => r.Email, "Sorry! Email already in use!");

        var usernameIsTaken = await Data.UserNameIsTaken(author.Username);

        ThrowIfAnyErrors();

        await Data.CreateNewAuthor(author);

        await SendAsync(new()
        {
            Message = $"Welcome {r.Username}! your request has been received!"
        });
    }
}