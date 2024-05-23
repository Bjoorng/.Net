using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using WebApi.Domains.Entities;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoLists.NewFolder;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/api/todo-lists/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        var todoList = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (todoList == null) 
        {
            await SendNotFoundAsync(ct);
        }

        await SendAsync(new Response(todoList!.Id, todoList!.Title, todoList!.IsDone, todoList!.Items), cancellation:ct);
    }
}
