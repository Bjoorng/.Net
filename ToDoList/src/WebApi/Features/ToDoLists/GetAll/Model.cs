using AutoMapper;
using WebApi.Domains.Entities;

namespace WebApi.Features.ToDoLists.GetAll;

public record Response(Guid Id, String Title, bool IsDone);

public class ResponseMapper : Profile
{
    public ResponseMapper()
    {
        CreateMap<TodoList, Response>();
    }
}