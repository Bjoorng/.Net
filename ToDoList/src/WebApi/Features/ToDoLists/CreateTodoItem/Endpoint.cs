using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.Domains.Entities;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoLists;

namespace WebApi.Features.ToDoLists.CreateTodoItem;

public class Endpoint(ApplicationDbContext context) : Endpoint<CreateItemRequest, CreateItemResponse>
{

    public override void Configure()
    {
        Post("/api/todo-lists/{TodoListId}/todo-item");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateItemRequest request, CancellationToken ct)
    {
        TodoList? todoList = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == request.TodoListId);
        
        if (todoList == null)
        {
            await SendNotFoundAsync(ct);
        }

        ListItem todoItem = todoList.AddItem(request.Title);    
        todoList.CheckList();
        context.Update(todoList);
        await context.SaveChangesAsync();

        await SendAsync(new CreateItemResponse(todoItem.Id), cancellation: ct);
    }

}
