using AutoMapper;

public class TestDetailsDTO()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SubjectId { get; set; }
    public int CategoryId { get; set; }
    public List<QuestionForTestDTO> Questions { get; set; }

    public class TestDetailsProfile : Profile{
        public TestDetailsProfile()
        {
            CreateMap<Test, TestDetailsDTO>();
        }
    }
}