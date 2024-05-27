﻿using FastEndpoints;
using WebApi.Infrastructure.Data;
using Shared.Models.ToDoItems;
using Shared.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.ToDoItems.UpdateDone;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<ItemUpdateDoneRequest, ItemUpdateDoneResponse>
{
    public override void Configure()
    {
        Put("/api/todo-items/done/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ItemUpdateDoneRequest request, CancellationToken ct)
    {
        ListItem? item = await context.ListItems.FindAsync(request.Id);
        TodoList? list = await context.TodoLists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == item.TodoListId);

        if (item == null)
        {
            await SendNotFoundAsync(ct);
        }

        item.UpdateDone();
        list.CheckList();

        await context.SaveChangesAsync();

        await SendAsync(new ItemUpdateDoneResponse(item.Text, item.IsDone), cancellation: ct);
    }
}