namespace TestAppBackend.Features.Answers.Delete;

public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<EmptyRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/answers/{id}");
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
        else
        {
            _dbContext.Answers.Remove(answer);
            await _dbContext.SaveChangesAsync();
            await SendNoContentAsync(ct);
        }
    }
}
