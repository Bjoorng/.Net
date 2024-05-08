using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

public class SubjectUpdateDTO()
{
    public string Name { get; set; }
    public List<CategorySubjectUpdateDTO> Categories { get; set; }
}