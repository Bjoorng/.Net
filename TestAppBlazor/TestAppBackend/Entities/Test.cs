namespace TestAppBackend.Entities;

public class Test
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Difficulty { get; private set; }
    public Guid? CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public List<Question>? Questions { get; private set; }

    protected Test() { }

    private Test(Guid id, string name, int difficulty)
    {
        this.Id = id;
        this.Name = name;
        this.Difficulty = difficulty;
    }

    public static Test Create(string name, int difficulty)
    {
        return new Test(new Guid(), name, difficulty);
    }
}