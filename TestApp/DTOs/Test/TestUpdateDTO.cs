public class TestUpdateDTO()
{
    public string Name { get; set; }
    public int SubjectId { get; set; }
    public int CategoryId { get; set; }
    public List<QuestionTestUpdateDTO> Questions { get; set; }
}