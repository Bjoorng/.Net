namespace Shared.Models.ToDoLists;

public record CreateItemRequest(string Title, Guid TodoListId);

public record CreateItemResponse(Guid Id);