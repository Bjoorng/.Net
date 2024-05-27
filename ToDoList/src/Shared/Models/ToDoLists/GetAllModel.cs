using AutoMapper;
using Shared.Domains.Entities;

namespace Shared.Models.ToDoLists;

public record GetAllResponse(Guid Id, string Title, bool IsDone);

public class ResponseMapper : Profile
{
    public ResponseMapper()
    {
        CreateMap<TodoList, GetAllResponse>();
    }
}