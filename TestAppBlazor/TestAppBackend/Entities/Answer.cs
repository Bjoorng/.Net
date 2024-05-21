namespace TestAppBackend.Entities;

public class Answer
{
    public Guid Id { get; private set; }
    public string Text { get; private set; }
    public bool IsCorrect { get; private set; }
    public Guid? QuestionId { get; private set; }
    public Question? Question { get; private set; }

    protected Answer() { }

    private Answer(Guid id, string text)
    {
        Id = id;
        Text = text;
        IsCorrect = false;
    }

    public static Answer Create(string text)
    {
        return new Answer(new Guid(), text);
    }

    public void Update(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }
}