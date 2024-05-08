using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Storage.Domain.Models;

namespace Storage.Domain.DTOs;

public class ProductCreateDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }

    public class ProductCreateProfile: Profile
    {
        public ProductCreateProfile() 
        {
            CreateMap<ProductCreateDTO, Product>()
                .ConstructUsing(o => Product.Create(o.Name, o.Price, o.Sku));
        }
    }

}
