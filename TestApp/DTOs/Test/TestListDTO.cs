using AutoMapper;

public class TestListDTO()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

    public class TestListDTOProfile : Profile{
        public TestListDTOProfile()
        {
            CreateMap<Test, TestListDTO>();
        }
    }
}