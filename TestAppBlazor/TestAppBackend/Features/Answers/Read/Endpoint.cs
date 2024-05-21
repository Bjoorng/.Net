namespace TestAppBackend.Features.Answers.Read;

public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<EmptyRequest, Models.Response>
{
    public override void Configure()
    {
        Get("/answers/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
    {
        Guid answerId = Route<Guid>("id");
        var answer = await _dbContext.Answers.FindAsync(answerId);
        if (answer == null)
        {
            await SendNotFoundAsync(ct);
        }

        await SendAsync(new Models.Response(answer.Id, answer.Text, answer.IsCorrect));
    }
}