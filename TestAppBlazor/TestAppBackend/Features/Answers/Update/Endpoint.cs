namespace TestAppBackend.Features.Answers.Update;


class Endpoint(ApplicationDbContext _dbContext) : Endpoint<Models.Request, Models.Response>
{
    public override void Configure()
    {
        Put("/answers/update/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.Request request, CancellationToken ct)
    {
        Guid answerId = Route<Guid>("id");
        Answer answer = await _dbContext.Answers.FindAsync(answerId);
        if (answer == null)
        {
            await SendNotFoundAsync(ct);
        }
        answer.Update(request.Text, request.IsCorrect);
        await _dbContext.SaveChangesAsync(ct);
        await SendAsync(new Models.Response(answer.Id, answer.Text, answer.IsCorrect));
    }
}
