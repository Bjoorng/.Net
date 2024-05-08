public class Question()
{
    public int Id { get; set; }
    public string Text { get; set; }    
    public int Difficulty { get; set; }
    public int CorrectAnswer { get; set; }
    public int? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public int? TestId { get; set; }
    public Test? Test { get; set; }
    public List<Answer> Answers { get; set; }
}