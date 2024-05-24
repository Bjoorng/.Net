using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.Models.ToDoLists;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoLists.NewFolder;

public class Endpoint(ApplicationDbContext context) : Endpoint<GetByIdRequest, GetByIdResponse>
{
    public override void Configure()
    {
        Get("/api/todo-lists/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetByIdRequest request, CancellationToken ct)
    {
        var todoList = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (todoList == null) 
        {
            await SendNotFoundAsync(ct);
        }

        await SendAsync(new GetByIdResponse(todoList!.Id, todoList!.Title, todoList!.IsDone, todoList!.Items), cancellation:ct);
    }
}
