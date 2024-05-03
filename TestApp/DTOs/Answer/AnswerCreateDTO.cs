using AutoMapper;

public class AnswerCreateDTO()
{
    public string Text { get; set; }

    public class AnswerCreateProfile : Profile {
        public AnswerCreateProfile()
        {
            CreateMap<AnswerCreateDTO, Answer>();
        }
    }
}