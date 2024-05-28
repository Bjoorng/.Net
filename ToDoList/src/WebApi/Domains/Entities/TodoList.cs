using WebApi.Domains.Entities.Common;
using System.Text.Json.Serialization;
using AutoMapper;
using Shared.Models.ToDoLists;

namespace WebApi.Domains.Entities;

public class TodoList : AuditableBaseEntity<Guid>
{
    public string Title { get; private set; }
    public bool IsDone { get; private set; }
    public List<ListItem>? Items { get; private set; }

    [JsonConstructor]
    private TodoList(Guid id, string title, bool isDone) : base(id)
    {
        Title = title;
        IsDone = isDone;
        Items = new List<ListItem>();
    }

    public static TodoList Create( string title)
    {
        return new TodoList(Guid.NewGuid(), title, false);
    }

    public string ChangeTitle(string text)
    {
        Title = text;
        LastModifiedBy = "Luca";
        LastModifiedIn = DateTime.UtcNow;
        return Title;
    }

    public void CheckList()
    {
        IsDone = Items != null && Items.Count > 0 && Items.All(item => item.IsDone);
    }

    public ListItem AddItem(string text)
    {
        ListItem item = ListItem.Create(text, Id);
        item.CreatedBy = "Luca";
        item.CreatedIn = DateTime.UtcNow;
        Items.Add(item);
        return item;
    }
}

public class ResponseMapper : Profile
{
    public ResponseMapper()
    {
        CreateMap<TodoList, GetAllResponse>();
    }
}
