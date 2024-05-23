using System.Text.Json.Serialization;
using WebApi.Domains.Entities.Common;

namespace WebApi.Domains.Entities;

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

    public static ListItem Create(string text, Guid todoListId)
    {
        return new ListItem(text, false, todoListId);
    }
}
