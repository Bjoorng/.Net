namespace TestAppBackend.Entities;

public class Question
{
    public Guid Id { get; private set; }
    public string Text { get; private set; }
    public int Difficulty { get; private set; }
    public Guid? SubjectId { get; private set; }
    public Subject? Subject { get; private set; }
    public Guid? CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public Guid? TestId { get; private set; }
    public Test? Test { get; private set; }
    public List<Answer>? Answers { get; private set; }

    protected Question() { }

    public Question(Guid id, string text, int difficulty)
    {
        this.Id = id;
        this.Text = text;
        this.Difficulty = difficulty;
    }

    public static Question Create(string text, int difficulty)
    {
        return new Question(new Guid(), text, difficulty);
    }

    public void AddAnswers(List<Answer> answerList)
    {
        Answers.Clear();
        Answers.AddRange(answerList);
    }

    public void Update(string text, int difficulty)
    {
        Text = text;
        Difficulty = difficulty;
    }

    public void AssignTo(Guid subjectId, Guid categoryId)
    {
        SubjectId = subjectId;
        CategoryId = categoryId;
    }
}