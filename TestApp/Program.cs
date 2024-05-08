using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.MapGet("/subjects", (ApplicationDbContext dbContext, IMapper mapper) => dbContext.Subjects.ProjectTo<SubjectListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/categories", (ApplicationDbContext dbContext, IMapper mapper) => dbContext.Categories.ProjectTo<CategoryListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/tests", (ApplicationDbContext dbContext, IMapper mapper) => dbContext.Tests.ProjectTo<TestListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/questions", (ApplicationDbContext dbContext, IMapper mapper) => dbContext.Questions.ProjectTo<QuestionListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/answers", (ApplicationDbContext dbContext, IMapper mapper) => dbContext.Answers.ProjectTo<AnswerListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/subjects/{id}", (ApplicationDbContext dbContext, int id, IMapper mapper) =>
{
    Subject s = dbContext.Subjects.Find(id);
    if (s == null)
    {
        return Results.NotFound();
    }
    SubjectDetailsDTO sdDto = new();
    sdDto.Id = s.Id;
    sdDto.Name = s.Name;
    sdDto.CategoryDTOs = dbContext.Categories.Where(c => c.SubjectId == s.Id).ProjectTo<CategoryForSubjectDTO>(mapper.ConfigurationProvider).ToList();
    return Results.Ok(sdDto);

});

app.MapGet("/categories/{id}", (ApplicationDbContext dbContext, int id, IMapper mapper) =>
{
    Category c = dbContext.Categories.Find(id);
    if (c == null)
    {
        return Results.NotFound();
    }
    CategoryDetailsDTO cdDto = new();
    cdDto.Id = c.Id;
    cdDto.Name = c.Name;
    cdDto.SubjectId = c.SubjectId ?? 0;
    cdDto.Tests = dbContext.Categories.Where(category => category.Id == c.Id).SelectMany(category => category.Tests).ProjectTo<TestListDTO>(mapper.ConfigurationProvider).ToList();
    return Results.Ok(cdDto);
});

app.MapGet("/tests/{id}", (ApplicationDbContext dbContext, int id, IMapper mapper) =>
{
    List<QuestionForTestDTO> questionsToRead = new();
    Test t = dbContext.Tests.Find(id);
    if (t == null)
    {
        return Results.NotFound();
    }
    TestDetailsDTO tdDto = new();
    tdDto.Name = t.Name;
    tdDto.CategoryId = t.CategoryId ?? 0;
    tdDto.Questions = dbContext.Tests.Where(test => test.Id == t.Id).SelectMany(test => test.Questions).ProjectTo<QuestionForTestDTO>(mapper.ConfigurationProvider).ToList();
    return Results.Ok(tdDto);
});

app.MapGet("/questions/{id}", (ApplicationDbContext dbContext, int id, IMapper mapper) =>
{
    List<AnswerDTO> answerRead = new();
    Question q = dbContext.Questions.Find(id);
    if (q == null)
    {
        return Results.NotFound();
    }
    QuestionDetailsDTO qdDto = new();
    qdDto.Id = q.Id;
    qdDto.Text = q.Text;
    qdDto.Difficulty = q.Difficulty;
    qdDto.CorrectAnswer = q.CorrectAnswer;
    qdDto.CategoryId = q.CategoryId;
    qdDto.SubjectId = q.SubjectId;
    qdDto.Answers = dbContext.Questions.Where(question => question.Id == q.Id).SelectMany(question => question.Answers).ProjectTo<AnswerDTO>(mapper.ConfigurationProvider).ToList();
    return Results.Ok(qdDto);
});

app.MapPost("/subjects/add", (ApplicationDbContext dbContext, IMapper mapper, SubjectCreateDTO scDto) =>
{
    SubjectValidator validator = new();
    ValidationResult result = validator.Validate(scDto);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    Subject s = mapper.Map<Subject>(scDto);
    dbContext.Add(s);
    dbContext.SaveChanges();
    return Results.Ok(scDto);
});

app.MapPost("/categories/add", (ApplicationDbContext dbContext, IMapper mapper, CategoryCreateDTO cDto) =>
{
    CategoryValidator validator = new();
    ValidationResult result = validator.Validate(cDto);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    if (dbContext.Subjects.Find(cDto.SubjectId) == null)
    {
        return Results.NotFound("Subject Not Found");
    }
    Category c = mapper.Map<Category>(cDto);
    dbContext.Add(c);
    dbContext.SaveChanges();
    return Results.Ok(cDto);
});

app.MapPost("/tests/add", (ApplicationDbContext dbContext, IMapper mapper, TestCreateDTO tDto) =>
{
    TestValidator validator = new();
    ValidationResult result = validator.Validate(tDto);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    if (dbContext.Subjects.Find(tDto.SubjectId) == null)
    {
        return Results.NotFound("Subject Not Found");
    }
    if (dbContext.Subjects.Find(tDto.CategoryId) == null)
    {
        return Results.NotFound("Category Not Found");
    }
    Test t = mapper.Map<Test>(tDto);
    dbContext.Add(t);
    dbContext.SaveChanges();
    return Results.Ok(tDto);
});

app.MapPost("/questions/add", (ApplicationDbContext dbContext, IMapper mapper, QuestionCreateDTO qDto) =>
{
    QuestionValidator validator = new();
    ValidationResult result = validator.Validate(qDto);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    if (dbContext.Subjects.Find(qDto.SubjectId) == null)
    {
        return Results.NotFound("Subject Not Found");
    }
    if (dbContext.Subjects.Find(qDto.CategoryId) == null)
    {
        return Results.NotFound("Category Not Found");
    }
    Question q = mapper.Map<Question>(qDto);
    dbContext.Add(q);
    dbContext.SaveChanges();
    return Results.Ok(qDto);
});

app.MapPost("/answers/add", (ApplicationDbContext dbContext, IMapper mapper, AnswerDTO aDto) =>
{
    AnswerValidator validator = new();
    ValidationResult result = validator.Validate(aDto);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    Answer a = mapper.Map<Answer>(aDto);
    dbContext.Add(a);
    dbContext.SaveChanges();
    return Results.Ok(aDto);
});

app.MapPut("/subject/update/{id}", (ApplicationDbContext dbContext, int id, SubjectUpdateDTO subjectUpdateDTO) =>
{
    Subject s = dbContext.Subjects.Find(id);
    if (s == null)
    {
        return Results.BadRequest();
    }
    s.Name = subjectUpdateDTO.Name;
    List<Category> categories = new();
    subjectUpdateDTO.Categories.ForEach(c =>
    {
        Category categoryToAdd = dbContext.Categories.Find(c.Id);
        if (categoryToAdd != null)
        {
            categories.Add(categoryToAdd);
        }
    });
    dbContext.Update(s);
    dbContext.SaveChanges();
    return Results.Ok(s);
});

app.MapPut("/categories/update/{id}", (ApplicationDbContext dbContext, int id, CategoryUpdateDTO cUpdateDto) =>
{
    Category c = dbContext.Categories.Include(c => c.Tests).Include(c => c.Questions).FirstOrDefault(c => c.Id == id);
    if (c == null)
    {
        return Results.BadRequest();
    }
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
    List<Question> questionList = new();
    cUpdateDto.Questions.ForEach(q =>
    {
        Question questionToAdd = dbContext.Questions.Find(q.Id);
        if (questionToAdd != null)
        {
            questionList.Add(questionToAdd);
        }
    });
    c.Tests = testList;
    dbContext.Update(c);
    dbContext.SaveChanges();
    return Results.Ok(c);
});

app.MapPut("/tests/update/{id}", (ApplicationDbContext dbContext, int id, TestUpdateDTO tUpdateDTO) =>
{
    Test t = dbContext.Tests.Include(t => t.Questions).FirstOrDefault(t => t.Id == id);
    if (t == null)
    {
        return Results.BadRequest();
    }
    t.Questions.Clear();
    t.Name = tUpdateDTO.Name;
    t.CategoryId = tUpdateDTO.CategoryId;
    List<Question> questionList = new();
    tUpdateDTO.Questions.ForEach(q =>
    {
        Question questionToAdd = dbContext.Questions.Find(q.Id);
        if (questionToAdd != null)
        {
            t.Difficulty += questionToAdd.Difficulty;
            questionList.Add(questionToAdd);
        }
    });
    t.Questions = questionList;
    dbContext.Update(t);
    dbContext.SaveChanges();
    return Results.Ok();

});

app.MapPut("/questions/update/{id}", (ApplicationDbContext dbContext, int id, QuestionUpdateDTO qUpdateDto) =>
{
    Question q = dbContext.Questions.Include(q => q.Answers).FirstOrDefault(q => q.Id == id);
    if (q == null)
    {
        return Results.BadRequest();
    }
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
    if (answerList.Count < 2)
    {
        return Results.BadRequest("Insert at least two answers");
    }
    else
    {
        q.Answers = answerList;
        dbContext.Update(q);
        dbContext.SaveChanges();
        return Results.Ok(q);
    }
});

app.MapPut("/answers/update/{id}", (ApplicationDbContext dbContext, int id, AnswerDTO aUpdateDto) =>
{
    Answer a = dbContext.Answers.Find(id);
    if (a == null)
    {
        return Results.BadRequest();
    }
    a.Text = aUpdateDto.Text;
    dbContext.Update(a);
    dbContext.SaveChanges();
    return Results.Ok(a);
});

app.MapDelete("/subjects/delete/{id}", (ApplicationDbContext dbContext, int id) =>
{
    dbContext.Subjects.Remove(dbContext.Subjects.Find(id));
    dbContext.SaveChanges();
});

app.MapDelete("/categories/delete/{id}", (ApplicationDbContext dbContext, int id) =>
{
    dbContext.Categories.Remove(dbContext.Categories.Find(id));
    dbContext.SaveChanges();
});

app.MapDelete("/tests/delete/{id}", (ApplicationDbContext dbContext, int id) =>
{
    dbContext.Tests.Remove(dbContext.Tests.Find(id));
    dbContext.SaveChanges();
});

app.MapDelete("/questions/delete/{id}", (ApplicationDbContext dbContext, int id) =>
{
    dbContext.Questions.Remove(dbContext.Questions.Find(id));
    dbContext.SaveChanges();
});

app.MapDelete("/answers/delete/{id}", (ApplicationDbContext dbContext, int id) =>
{
    dbContext.Answers.Remove(dbContext.Answers.Find(id));
    dbContext.SaveChanges();
});

app.Run();
