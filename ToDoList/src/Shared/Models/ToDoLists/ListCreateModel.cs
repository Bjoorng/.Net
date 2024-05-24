namespace Shared.Models.ToDoLists;
public record CreateRequest(string Title);

public record CreateResponse(Guid Id);
