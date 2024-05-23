using AutoMapper.QueryableExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Data;

namespace WebApi.Features.ToDoLists.GetAll;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<Response>>
{
    public override void Configure()
    {
        Get("/api/todo-lists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
    {
        List<Response> lists = await context.TodoLists.ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(lists, cancellation: ct);
    }
}
