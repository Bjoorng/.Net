public class Answer()
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Question>? Questions { get; set; }
}