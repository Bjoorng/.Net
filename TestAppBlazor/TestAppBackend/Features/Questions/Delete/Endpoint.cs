namespace TestAppBackend.Features.Questions.Delete;

public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<EmptyRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/questions/delete/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
    {
        Guid questionId = Route<Guid>("id");
        var question = await _dbContext.Answers.FindAsync(questionId);
        if (question == null)
        {
            await SendNotFoundAsync(ct);
        }
        else
        {
            _dbContext.Answers.Remove(question);
            await _dbContext.SaveChangesAsync();
            await SendNoContentAsync(ct);
        }
    }
}
