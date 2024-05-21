namespace TestAppBackend.Features.Questions.ReadAll
{
    public class Models
    {
        public record Response(List<Question> Questions);
    }
}
