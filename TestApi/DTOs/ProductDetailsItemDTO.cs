using AutoMapper;
using Microsoft.AspNetCore.Components.Web;

public class ProductDetailsItemDTO()
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public class ProductDetailsItemProfile : Profile {
        public ProductDetailsItemProfile()
        {
            CreateMap<Product, ProductDetailsItemDTO>().ForMember(x => x.Title, opt => opt.MapFrom(y => y.Name));
        }
    }
}