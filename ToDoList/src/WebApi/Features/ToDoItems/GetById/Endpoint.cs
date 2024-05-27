using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.Models.ToDoItems;
using Shared.Models.ToDoLists;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoItems.GetById;

public class Endpoint(ApplicationDbContext context) : Endpoint<ItemByIdRequest, ItemByIdResponse>
{
    public override void Configure()
    {
        Get("/api/todo-items/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ItemByIdRequest request, CancellationToken ct)
    {
        var item = await context.ListItems.FindAsync(request.Id);

        if (item == null)
        {
            await SendNotFoundAsync(ct);
        }

        await SendAsync(new ItemByIdResponse(item!.Id, item!.Text, item!.IsDone, item!.TodoListId), cancellation: ct);
    }
}
