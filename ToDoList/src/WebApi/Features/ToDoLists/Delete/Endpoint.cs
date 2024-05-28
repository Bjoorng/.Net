using FastEndpoints;
using WebApi.Domains.Entities;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoLists;

namespace WebApi.Features.ToDoLists.Delete;

public class Endpoint(ApplicationDbContext context) : Endpoint<DeleteRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/api/todo-lists/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRequest request, CancellationToken ct)
    {
        TodoList list = await context.TodoLists.FindAsync(request.Id);

        if (list == null)
        {
            await SendNotFoundAsync(ct);
        }

        context.Remove(list);
        await context.SaveChangesAsync();

        await SendNoContentAsync(cancellation: ct);
    }
}
