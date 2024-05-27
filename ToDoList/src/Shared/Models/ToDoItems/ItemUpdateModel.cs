namespace Shared.Models.ToDoItems;

public record ItemUpdateRequest(Guid Id, string Text, bool IsDone);
public record ItemUpdateResponse(string Title, bool IsDone);