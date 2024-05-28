using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.Models.ToDoLists;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoLists.NewFolder;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<GetByIdRequest, GetByIdResponse>
{
    public override void Configure()
    {
        Get("/api/todo-lists/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetByIdRequest request, CancellationToken ct)
    {
        var todoList = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == request.Id);
        var itemsList = new List<ItemForListResponse>();

        if (todoList == null) 
        {
            await SendNotFoundAsync(ct);
        }

        todoList.Items.ForEach(item =>
        {
            ItemForListResponse response = mapper.Map<ItemForListResponse>(item);
            itemsList.Add(response);
        });

        await SendAsync(new GetByIdResponse(todoList!.Id, todoList!.Title, todoList!.IsDone, itemsList), cancellation:ct);
    }
}
