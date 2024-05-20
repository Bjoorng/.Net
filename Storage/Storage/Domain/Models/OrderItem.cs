namespace Storage.Domain.Models;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }@
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    private OrderItem(Guid id, Guid productId, decimal price, int quantity)
    {
        Id = id;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public static OrderItem Create(Product product, int quantity)
    {
        decimal price = product.Price * quantity;
        return new OrderItem(Guid.NewGuid(), product.Id, price, quantity);
    }
}
