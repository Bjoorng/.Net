using AutoMapper;

public class TestDetailsDTO()
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public List<QuestionForTestDTO> Questions { get; set; }

    public class TestDetailsProfile : Profile{
        public TestDetailsProfile()
        {
            CreateMap<Test, TestDetailsDTO>();
        }
    }
}