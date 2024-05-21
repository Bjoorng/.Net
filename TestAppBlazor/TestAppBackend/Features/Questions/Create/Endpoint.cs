namespace TestAppBackend.Features.Questions.Create;

public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<Models.Request, Models.Response>
{
    public override void Configure()
    {
        Post("/questions/CreateAnswer");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.Request request, CancellationToken cancellationToken)
    {
        Question question = Question.Create(request.Text, request.Difficulty);
        
        await _dbContext.Questions.AddAsync(question);
        await _dbContext.SaveChangesAsync();

        await SendAsync(new Models.Response(question.Text, question.Difficulty));
    }
}
