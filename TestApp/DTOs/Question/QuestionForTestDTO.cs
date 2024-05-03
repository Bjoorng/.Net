using AutoMapper;

public class QuestionForTestDTO()
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public List<AnswerForQuestionDTO> Answers { get; set; }

    public class QuestionCreateProfile : Profile{
        public QuestionCreateProfile()
        {
            CreateMap<Question, QuestionForTestDTO>();
        }
    }
}