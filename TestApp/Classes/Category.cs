public class Category()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public List<Test>? Tests { get; set; }
    public List<Question>? Questions { get; set; }
}