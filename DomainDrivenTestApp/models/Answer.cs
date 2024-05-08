public class Answer{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }

    private Answer(string title, bool isCorrect, int questionId){
        Title = title;
        IsCorrect = isCorrect;
        QuestionId = questionId;
    }

    public static Answer Create(string title, int questionId, bool isCorrect){
        return new Answer(title, isCorrect, questionId);
    }
}