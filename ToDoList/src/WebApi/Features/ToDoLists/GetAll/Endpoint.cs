using AutoMapper.QueryableExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoLists;

namespace WebApi.Features.ToDoLists.GetAll;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<GetAllResponse>>
{
    public override void Configure()
    {
        Get("/api/todo-lists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
    {
        List<GetAllResponse> lists = await context.TodoLists.ProjectTo<GetAllResponse>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(lists, cancellation: ct);
    }
}
