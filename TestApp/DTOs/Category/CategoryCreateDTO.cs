using AutoMapper;

public class CategoryCreateDTO()
{
    public string Name { get; set; }
    public int SubjectId { get; set; }

    public class CategoryCreateProfile : Profile{
        public CategoryCreateProfile()
        {
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}