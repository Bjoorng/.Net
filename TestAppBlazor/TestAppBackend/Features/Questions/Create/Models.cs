namespace TestAppBackend.Features.Questions.Create;

public class Models
{
    public record Request(string Text, int Difficulty);
    public record Response(string Text, int Difficulty);
}
