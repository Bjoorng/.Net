using FastEndpoints;
using WebApi.Domains.Entities;
using WebApi.Infrastructure.Data;
using WebApi.Features.ToDoLists.Create;

namespace WebApi.Features.ToDoLists.Create;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/todo-lists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        var toDoList = TodoList.Create(request.Title);
        toDoList.CreatedBy = "Luca";
        toDoList.CreatedIn = DateTime.UtcNow;
        await context.TodoLists.AddAsync(toDoList, ct);
        await context.SaveChangesAsync();

        await SendAsync(new Response(toDoList.Id), cancellation: ct);
    }

}
