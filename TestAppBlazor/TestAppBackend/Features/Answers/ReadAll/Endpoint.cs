namespace TestAppBackend.Features.Answers.ReadAll;

public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<EmptyRequest,Models.Response>
{
    public override void Configure()
    {
        Get("/answers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
    { 
        List<Answer> answers = await _dbContext.Answers.ToListAsync();

        await SendAsync(new Models.Response(answers));
    }
}
