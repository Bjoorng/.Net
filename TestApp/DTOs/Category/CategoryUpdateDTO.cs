using AutoMapper;

public class CategoryUpdateDTO()
{
    public string Name { get; set; }
    public int SubjectId { get; set; }
    public List<TestCategoryUpdateDTO> Tests { get; set; }
}