namespace Shared.Models.ToDoLists;

public record CreateItemRequest(string Text, Guid TodoListId);

public record CreateItemResponse(Guid Id);