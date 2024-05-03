using AutoMapper;

public class AnswerListDTO {
    public int Id { get; set; }
    public string Text { get; set; }

    public class AnswerListProfile : Profile{
        public AnswerListProfile()
        {
            CreateMap<Answer, AnswerListDTO>();
        }
    }
}