namespace Shared.Models.ToDoItems;

public record ItemByIdRequest(Guid Id);
public record ItemByIdResponse(Guid Id, string Text, bool IsDone, Guid ListId);
