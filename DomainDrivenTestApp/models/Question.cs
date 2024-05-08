public class Question{
    public int Id { get; private set; }
    public string Title { get; private set; }
    private List<Answer> Answers;
    public IReadOnlyCollection<Answer> AnswerList => Answers.ToList();

    private Question(string title, List<Answer> answerList){
        Title = title;
        Answers = answerList;
    }

    public static Question Create(string title, List<Answer> answerList){
        return answerList.Count() >= 4 && answerList.Where(a => a.IsCorrect).Count() >= 1 ? new Question(title, answerList) : null;
    }

    public void AddAnswer(string title, bool isCorrect){
        Answers.Add(Answer.Create(title, this.Id, isCorrect));
    }

    public void RemoveAnswer(int index){
        Answers.Remove(Answers[index]);
    }
}