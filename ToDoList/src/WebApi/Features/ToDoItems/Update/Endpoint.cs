using FastEndpoints;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoItems;
using WebApi.Domains.Entities;

namespace WebApi.Features.ToDoItems.Update;

public class Endpoint(ApplicationDbContext context) : Endpoint<ItemUpdateRequest, ItemUpdateResponse>
{
    public override void Configure()
    {
        Put("/api/todo-items/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ItemUpdateRequest request, CancellationToken ct)
    {
        ListItem? item = await context.ListItems.FindAsync(request.Id);
        TodoList? list = await context.TodoLists.FindAsync(item.TodoListId);

        if (item == null)
        {
            await SendNotFoundAsync(ct);
        }

        item.Update(request.Text, request.IsDone);
        list.CheckList();

        await context.SaveChangesAsync();

        await SendAsync(new ItemUpdateResponse(item.Text, item.IsDone), cancellation: ct);
    }
}
