namespace TestAppBackend.Features.Answers.Update;

public class Models
{
    public record Request(string Text, bool IsCorrect);
    public record Response(Guid Id, string Text, bool IsCorrect);
}
