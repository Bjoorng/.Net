namespace TestAppBackend.Features.Answers.Create;

class Endpoint(ApplicationDbContext _dbContext) : Endpoint<Models.Request, Models.Response>
{
    public override void Configure()
    {
        Post("/answers/CreateAnswer");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.Request request, CancellationToken ct)
    {
        Answer answer = Answer.Create(request.text);

        await _dbContext.Answers.AddAsync(answer);
        await _dbContext.SaveChangesAsync(ct);

        await SendAsync(new Models.Response(answer.Text));
    }
}