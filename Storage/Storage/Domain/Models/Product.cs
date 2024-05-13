using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Storage.Domain.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; } = 0;
    public string Sku { get; private set; }
    public int Quantity { get; private set; }

    private Product(Guid id, string name, string description, decimal price, string sku, int quantity)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Sku = sku;
        Quantity = quantity;
    }

    public static Product Create(string name, decimal price, string sku)
    {
        return new Product(Guid.NewGuid(), name, string.Empty, price, sku, 0);
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity > 0)
        {
            this.Quantity = quantity;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(Quantity));
        }
    }

    public void UpdateQuantityDelete(int quantity)
    {
        this.Quantity += quantity;
    }

    public void UpdateQuantityOrder(int quantity)
    {
        if(this.Quantity > 0)
        {
            this.Quantity -= quantity;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(Quantity));
        }
    }
}