using System.Text.Json.Serialization;
using Shared.Domains.Entities.Common;

namespace Shared.Domains.Entities;

public class ListItem : AuditableBaseEntity<Guid>
{
    public string Text { get; private set; }
    public bool IsDone { get; private set; }
    public Guid TodoListId { get; private set; }
    [JsonIgnore]
    public TodoList TodoList { get; private set; }

    private ListItem(string text, bool isDone, Guid todoListId) : base()
    {
        Text = text;
        IsDone = isDone;
        TodoListId = todoListId;
    }

    [JsonConstructor]
    private ListItem(Guid id, string text, bool isDone, Guid todoListId) : base(id)
    {
        Text = text;
        IsDone = isDone;
        TodoListId = todoListId;
    }

    public static ListItem Create(string text, Guid todoListId)
    {
        return new ListItem(text, false, todoListId);
    }

    public void Update(string text, bool isDone)
    {
        Text = text;
        IsDone = isDone;
        LastModifiedBy = "Luca";
        LastModifiedIn = DateTime.UtcNow;
    }

    public void UpdateDone()
    {
        IsDone = !IsDone;
        LastModifiedBy = "Luca";
        LastModifiedIn = DateTime.UtcNow;
    }
}
