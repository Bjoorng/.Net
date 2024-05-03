using AutoMapper;

public class TestCreateDTO()
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubjectId { get; set; }

    public class TestCreateProfile : Profile{
        public TestCreateProfile()
        {
            CreateMap<TestCreateDTO, Test>();
        }
    }
}