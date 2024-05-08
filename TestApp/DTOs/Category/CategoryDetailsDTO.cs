using AutoMapper;

public class CategoryDetailsDTO(){
    public int Id { get; set; }
    public string Name { get; set; }
    public int? SubjectId { get; set; }
    public List<TestListDTO> Tests { get; set; }

    public class CategoryDetailsProfile: Profile{
        public CategoryDetailsProfile()
        {
            CreateMap<Category, CategoryDetailsDTO>();
        }
    }
}