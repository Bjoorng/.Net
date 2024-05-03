using AutoMapper;

public class AnswerForQuestionDTO()
{
    public string Text { get; set; }

    public class AnswerForQuestionProfile : Profile{
        public AnswerForQuestionProfile()
        {
            CreateMap<Answer, AnswerForQuestionDTO>();
        }
    }
}