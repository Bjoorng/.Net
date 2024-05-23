namespace WebApi.Features.ToDoLists.Create;

public record Request(string Title);

public record Response(Guid Id);
