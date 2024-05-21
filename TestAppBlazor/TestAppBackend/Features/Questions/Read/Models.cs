namespace TestAppBackend.Features.Questions.Read
{
    public class Models
    {
        public record Response(Guid Id, string Text, int Difficulty);
    }
}
