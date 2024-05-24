namespace Shared.Models.ToDoItems;

public record UpdateRequest(Guid Id, string Text, bool IsDone);
public record UpdateResponse(string text, bool IsDone);