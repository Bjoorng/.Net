namespace Storage.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public List<OrderItem>? Items { get; set; }

    private Order(Guid id, DateTime date)
    {
        Id = id;
        Date = date;
    }

    public static Order Create(List<OrderItem> items)
    {
        if (items.Count > 0)
        {
            Order order = new(Guid.NewGuid(), DateTime.Now);
            order.Items = items;
            return order;
        }
        throw new InvalidOperationException("You can't create an order without products");
    }

}
