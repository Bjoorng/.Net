namespace TestAppBackend.Features.Questions.Update
{
    public class Models
    {
        public record Request(string Text, int Difficulty);
        public record Response(Guid Id, string Text, int Difficulty);
    }
}
