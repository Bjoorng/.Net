namespace Shared.Models.ToDoItems;

public record ItemUpdateDoneRequest(Guid Id);
public record ItemUpdateDoneResponse(string Title, bool ItemIsDone);