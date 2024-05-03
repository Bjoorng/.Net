using AutoMapper;

public class SubjectCreateDTO()
{
    public string Name { get; set; }

    public class SubjectCreateProfile : Profile{
        public SubjectCreateProfile()
        {
            CreateMap<SubjectCreateDTO, Subject>();
        }
    }
}