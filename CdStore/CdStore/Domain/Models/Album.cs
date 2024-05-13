namespace Store.Domain.Models;

public class Album
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Artist { get; set; }
    public string Sku { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
}