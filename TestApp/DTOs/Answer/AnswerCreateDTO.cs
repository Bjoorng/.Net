using AutoMapper;

public class AnswerDTO()
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public class AnswerProfile : Profile {
        public AnswerProfile()
        {
            CreateMap<AnswerDTO, Answer>();
        }
    }
}