namespace WebApi.Features.ToDoLists.CreateTodoItem;

public record Request(string Text, Guid TodoListId);

public record Response(Guid Id);