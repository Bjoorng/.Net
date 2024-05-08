using AutoMapper;
using Storage.Domain.Models;

namespace Storage.Domain.DTOs;

public class ProductDetailsDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int Quantity { get; set; }

    public class ProductDetailsProfile: Profile
    {
        public ProductDetailsProfile()
        {
            CreateMap<Product, ProductDetailsProfile>();
        }
    }
}

