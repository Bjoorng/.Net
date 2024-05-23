using WebApi.Domains.Entities.Common;

namespace WebApi.Domains.Entities;

public class TodoList : AuditableBaseEntity<Guid>
{
    public string Title { get; private set; }
    public bool IsDone { get; private set; }
    public List<ListItem>? Items { get; private set; }

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

    //public void CheckList()
    //{
    //    int counter = 0;
    //    foreach (var item in Items)
    //    {
    //        if (item.IsDone)
    //        {
    //            counter++;
    //        }
    //    }
    //    if(counter == Items.Count && counter > 0 && Items.Count > 0)
    //    {
    //        IsDone = true;
    //    }
    //}

    public ListItem AddItem(string text)
    {
        ListItem item = ListItem.Create(text, Id);
        item.CreatedBy = "Luca";
        item.CreatedIn = DateTime.UtcNow;
        Items.Add(item);
        return item;
    }
}
