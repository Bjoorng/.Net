public class Test()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<Question> Questions { get; set; }
}