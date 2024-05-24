using FastEndpoints;
using Shared.Domains.Entities;
using Shared.Models.ToDoLists;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoLists.Update;

public class Endpoint(ApplicationDbContext context) : Endpoint<UpdateRequest, UpdateResponse>
{
    public override void Configure()
    {
        Put("/api/todo-lists/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateRequest req, CancellationToken ct)
    {
        TodoList list = await context.TodoLists.FindAsync(req.Id);
        if(list == null)
        {
            await SendNotFoundAsync(ct);
        }
        list.ChangeTitle(req.Text);

        await context.SaveChangesAsync(ct);

        await SendAsync(new UpdateResponse($"List title changed to: {list.Title}"), cancellation: ct);
    }
}
