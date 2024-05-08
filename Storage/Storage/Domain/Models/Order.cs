namespace Storage.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }

    private Order(Guid id, DateTime date)
    {
        Id = id;
    }

    public static Order Create(List<Product> products)
    {
        return products.Count > 0 ? new Order(new Guid(), products) : null;
    }

}
