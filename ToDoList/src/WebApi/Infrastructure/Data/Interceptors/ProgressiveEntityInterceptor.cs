using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi.Domains.Entities;
using WebApi.Services;

namespace WebApi.Infrastructure.Data.Interceptors;

public class ProgressiveEntityInterceptor() : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<IProgressive>())
        {
            if (entry.Entity.GetType().Equals(typeof(TodoList)))
            {
                foreach (var collection in entry.Collections)
                {
                    if (collection.CurrentValue is List<ListItem> toDoItems)
                    {
                        if (toDoItems.Any(item => entry.Context.Entry(item).State == EntityState.Added))
                        {
                            entry.Entity.ProgressiveInt++;
                        }
                    }
                }
            }
        }
    }
}

