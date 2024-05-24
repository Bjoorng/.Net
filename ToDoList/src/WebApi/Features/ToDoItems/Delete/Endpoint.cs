using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.Domains.Entities;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoItems;

namespace WebApi.Features.ToDoItems.Delete;

public class Endpoint(ApplicationDbContext context) : Endpoint<DeleteRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/api/todo-items/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        ListItem? item = await context.ListItems.FindAsync(req.Id);
        TodoList? list = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == item.TodoListId);

        if(item == null)
        {
            await SendNotFoundAsync(ct);
        }

        list.Items.Remove(item);
        context.Remove(item);
        list.CheckList();
        context.Update(list);
        await context.SaveChangesAsync();

        await SendNoContentAsync(ct);
    }
}
