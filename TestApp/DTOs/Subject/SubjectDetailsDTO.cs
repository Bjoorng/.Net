using AutoMapper;

public class SubjectDetailsDTO(){
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CategoryForSubjectDTO> CategoryDTOs { get; set; }

    public class SubjectListProfile : Profile{
        public SubjectListProfile()
        {
            CreateMap<Subject, SubjectListDTO>();
        }
    }
}