using WebApi.Domains.Entities;

namespace WebApi.Features.ToDoLists.NewFolder;

public record Request(Guid Id);
public record Response(Guid Id, string Text, bool IsDone, List<ListItem> ListItems);
