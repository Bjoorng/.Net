using AutoMapper;

public class CategoryListDTO()
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class CategoryListProfile : Profile{
        public CategoryListProfile(){
            CreateMap<Category, CategoryListDTO>();
        }
    }
}