public class QuestionUpdateDTO()
{
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public int CorrectAnswer { get; set; }
    public int CategoryId { get; set; }
    public int SubjectId { get; set; }
    public List<AnswerQuestionUpdateDTO> Answers { get; set; }
}