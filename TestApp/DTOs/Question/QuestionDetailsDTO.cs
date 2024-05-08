using AutoMapper;

public class QuestionDetailsDTO()
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public int CorrectAnswer { get; set; }
    public int? CategoryId { get; set; }
    public int? SubjectId { get; set; }
    public List<AnswerDTO> Answers { get; set; }

    public class QuestionDetailsProfile : Profile
    {
        public QuestionDetailsProfile()
        {
            CreateMap<Question, QuestionDetailsDTO>();
        }
    }
}