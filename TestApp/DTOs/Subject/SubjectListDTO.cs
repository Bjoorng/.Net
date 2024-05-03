using AutoMapper;

public class SubjectListDTO(){
    
    public string Name { get; set; }

    public class SubjectListProfile : Profile{
        public SubjectListProfile()
        {
            CreateMap<Subject, SubjectListDTO>();
        }
    }
}