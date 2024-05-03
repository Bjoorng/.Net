using AutoMapper;

public class CategoryForSubjectDTO()
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class CategoryForSubjectProfile : Profile{
        public CategoryForSubjectProfile()
        {
            CreateMap<Category, CategoryForSubjectDTO>();
        }
    }
    
}