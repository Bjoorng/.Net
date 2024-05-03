using AutoMapper;

public class QuestionCreateDTO()
{
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public int CategoryId { get; set; }
    public int SubjectId { get; set; }

    public class QuestionCreateProfile : Profile{
        public QuestionCreateProfile()
        {
            CreateMap<QuestionCreateDTO, Question>();
        }
    }
}