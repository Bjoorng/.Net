using AutoMapper;

namespace Storage.Domain.DTOs.ProductDTOs;

public class ProductListDTO()
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }

    public class ProductListProfile : Profile
    {
        public ProductListProfile()
        {
            CreateMap<ProductListProfile, ProductListDTO>();
        }
    }
}

