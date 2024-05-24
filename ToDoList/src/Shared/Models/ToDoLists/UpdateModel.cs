namespace Shared.Models.ToDoLists;

public record UpdateRequest(Guid Id, string Text);

public record UpdateResponse(string Title);
