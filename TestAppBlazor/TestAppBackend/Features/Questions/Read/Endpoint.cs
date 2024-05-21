namespace TestAppBackend.Features.Questions.Read
{
    public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<EmptyRequest, Models.Response>
    {
        public override void Configure()
        {
            Get("/questions/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
        {
            Guid questionId = Route<Guid>("id");
            var question = await _dbContext.Questions.FindAsync(questionId);

            if (question == null)
            {
                await SendNotFoundAsync(ct);
            }

            await SendAsync(new Models.Response(question.Id, question.Text, question.Difficulty));
        }
    }
}
