using AutoMapper;

public class QuestionListDTO()
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Difficulty { get; set; }
    
    public class QuestionListProfile : Profile{
        public QuestionListProfile()
        {
            CreateMap<Question, QuestionListDTO>();
        }
    }
}