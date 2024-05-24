using Shared.Domains.Entities;

namespace Shared.Models.ToDoLists;

public record GetByIdRequest(Guid Id);
public record GetByIdResponse(Guid Id, string Text, bool IsDone, List<ListItem> ListItems);
