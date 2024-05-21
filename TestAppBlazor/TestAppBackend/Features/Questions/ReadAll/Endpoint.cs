namespace TestAppBackend.Features.Questions.ReadAll
{
    public class Endpoint(ApplicationDbContext _dbContext) : Endpoint<EmptyRequest, Models.Response>
    {
        public override void Configure()
        {
            Get("/questions");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
        {
            List<Question> questions = await _dbContext.Questions.ToListAsync();

            await SendAsync(new Models.Response(questions));
        }
    }
}
