namespace TestAppBackend.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid? SubjectId { get; private set; }
    public Subject? Subject { get; private set; }
    public List<Test>? Tests { get; private set; }
    public List<Question>? Questions { get; private set; }

    protected Category() { }

    private Category(Guid id, string name, Guid subjectId)
    {
        this.Id = id;
        this.Name = name;
        this.SubjectId = subjectId;
    }

    public static Category Create(string name, Guid subjectId)
    {
        return new Category(new Guid(), name, subjectId);
    }
}