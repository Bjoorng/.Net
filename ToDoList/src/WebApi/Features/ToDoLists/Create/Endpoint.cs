using FastEndpoints;
using Shared.Domains.Entities;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoLists;

namespace WebApi.Features.ToDoLists.Create;

public class Endpoint(ApplicationDbContext context) : Endpoint<CreateRequest, CreateResponse>
{
    public override void Configure()
    {
        Post("/api/todo-lists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRequest request, CancellationToken ct)
    {
        var toDoList = TodoList.Create(request.Title);
        toDoList.CreatedBy = "Luca";
        toDoList.CreatedIn = DateTime.UtcNow;
        await context.TodoLists.AddAsync(toDoList, ct);
        await context.SaveChangesAsync();

        await SendAsync(new CreateResponse(toDoList.Id), cancellation: ct);
    }

}
