namespace TestAppBackend.Entities;

public class Subject
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<Category>? Categories { get; private set; }

    protected Subject() { }
    private Subject(Guid id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public static Subject Create(string name){
        return new Subject(Guid.NewGuid(), name);
    }

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }
}