using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
ApplicationDbContext dbContext = new();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/subjects", (IMapper mapper) => dbContext.Subjects.ProjectTo<SubjectListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/subjects/{id}", (int id, IMapper mapper) =>
{
    Subject s = dbContext.Subjects.Find(id);
    if (s != null)
    {
        SubjectDetailsDTO sdDto = new();
        sdDto.Id = s.Id;
        sdDto.Name = s.Name;
        sdDto.CategoryDTOs = dbContext.Categories.Where(c => c.SubjectId == s.Id).ProjectTo<CategoryForSubjectDTO>(mapper.ConfigurationProvider).ToList();
        return Results.Ok(sdDto);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/subjects", (IMapper mapper, SubjectCreateDTO scDto) =>
{
    Subject s = mapper.Map<Subject>(scDto);
    dbContext.Add(s);
    dbContext.SaveChanges();
});

app.MapGet("/categories", (IMapper mapper) => dbContext.Categories.ProjectTo<CategoryListDTO>(mapper.ConfigurationProvider).ToList());

app.MapPost("/categories/add", (IMapper mapper, CategoryCreateDTO cDto) =>
{
    Category c = mapper.Map<Category>(cDto);
    dbContext.Add(c);
    dbContext.SaveChanges();
});

app.MapPut("/categories/update/{id}", (int id, CategoryUpdateDTO cUpdateDto) =>
{
    Category c = dbContext.Categories.Find(id);
    if (c != null)
    {
        c.Name = cUpdateDto.Name;
        c.SubjectId = cUpdateDto.SubjectId;
        List<Test> testList = new();
        cUpdateDto.Tests.ForEach(t =>
        {
            Test testToAdd = dbContext.Tests.Find(t.Id);
            if (testToAdd != null)
            {
                testList.Add(testToAdd);
            }
        });
        c.Tests = testList;
        dbContext.Update(c);
        dbContext.SaveChanges();
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest();
    }
});

app.MapGet("/tests", (IMapper mapper) => dbContext.Tests.ProjectTo<TestListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/tests/{id}", (int id, IMapper mapper) =>
{
    List<QuestionForTestDTO> questionsToRead = new();
    Test t = dbContext.Tests.Find(id);
    if (t != null)
    {
        TestDetailsDTO tdDto = new();
        tdDto.Name = t.Name;
        tdDto.CategoryId = t.CategoryId ?? 0;
        tdDto.Questions = dbContext.Tests.Where(test => test.Id == t.Id).SelectMany(test => test.Questions).ProjectTo<QuestionForTestDTO>(mapper.ConfigurationProvider).ToList();
        return Results.Ok(tdDto);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/tests/add", (IMapper mapper, TestCreateDTO tDto) =>
{
    Test t = mapper.Map<Test>(tDto);
    dbContext.Add(t);
    dbContext.SaveChanges();

});

app.MapPut("/tests/update/{id}", (int id, TestUpdateDTO tUpdateDTO) =>
{
    Test t = dbContext.Tests.Include(t => t.Questions).FirstOrDefault(t => t.Id == id);
    if (t != null)
    {
        t.Questions.Clear();
        t.Name = tUpdateDTO.Name;
        t.CategoryId = tUpdateDTO.CategoryId;
        List<Question> questionList = new();
        tUpdateDTO.Questions.ForEach(q =>
        {
            Question questionToAdd = dbContext.Questions.Find(q.Id);
            if (questionToAdd != null)
            {
                questionList.Add(questionToAdd);
            }
        });
        t.Questions = questionList;
        dbContext.Update(t);
        dbContext.SaveChanges();
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest();
    }
});

app.MapGet("/questions", (IMapper mapper) => dbContext.Questions.ProjectTo<QuestionListDTO>(mapper.ConfigurationProvider).ToList());

app.MapPost("/questions", (IMapper mapper, QuestionCreateDTO qDto) =>
{
    Question q = mapper.Map<Question>(qDto);
    dbContext.Add(q);
    dbContext.SaveChanges();
});

app.MapPut("/questions/update/{id}", (int id, QuestionUpdateDTO qUpdateDto) =>
{
    Question q = dbContext.Questions.Include(q => q.Answers).FirstOrDefault(q => q.Id == id);
    if (q != null)
    {
        q.Answers.Clear();
        q.Text = qUpdateDto.Text;
        q.Difficulty = qUpdateDto.Difficulty;
        q.CorrectAnswer = qUpdateDto.CorrectAnswer;
        q.CategoryId = qUpdateDto.CategoryId;
        q.SubjectId = qUpdateDto.SubjectId;
        List<Answer> answerList = new List<Answer>();
        qUpdateDto.Answers.ForEach(ans =>
        {
            Answer answerToAdd = dbContext.Answers.Find(ans.Id);
            if (answerToAdd != null)
            {
                answerList.Add(answerToAdd);
            }
        });
        q.Answers = answerList;
        dbContext.Update(q);
        dbContext.SaveChanges();
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest();
    }
});

app.MapGet("/answers", (IMapper mapper) => dbContext.Answers.ProjectTo<AnswerListDTO>(mapper.ConfigurationProvider).ToList());

app.MapPost("/answers", (IMapper mapper, AnswerCreateDTO aDto) =>
{
    Answer a = mapper.Map<Answer>(aDto);
    dbContext.Add(a);
    dbContext.SaveChanges();
});

app.Run();
