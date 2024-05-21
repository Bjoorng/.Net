namespace TestAppBackend.Features.Questions.Update
{
    public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<Models.Request, Models.Response>
    {
        public override void Configure()
        {
            Put("/questions/update/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Models.Request request, CancellationToken ct) 
        {
            Guid questionId = Route<Guid>("id");
            Question question = await _dbContext.Questions.FindAsync(questionId);
            if(question == null) 
            {
                await SendNotFoundAsync(ct);
            }
            question.Update(request.Text, request.Difficulty);
            await SendAsync(new Models.Response(question.Id, question.Text, question.Difficulty));
        }
    }
}
