namespace TestAppBackend.Features.Answers.Read;

public class Models
{
    public record Response(Guid Id, string Text, bool IsCorrect);
}
