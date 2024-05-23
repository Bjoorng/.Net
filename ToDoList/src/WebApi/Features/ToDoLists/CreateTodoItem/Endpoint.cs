using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using WebApi.Domains.Entities;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoLists.CreateTodoItem;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{

    public override void Configure()
    {
        Post("/api/todo-lists/{TodoListId}/todo-item");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        TodoList? todoList = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == request.TodoListId);
        
        if (todoList == null)
        {
            await SendNotFoundAsync(ct);
        }

        ListItem todoItem = todoList.AddItem(request.Text);
        await context.SaveChangesAsync();

        await SendAsync(new Response(todoItem.Id), cancellation: ct);
    }

}
