using AutoMapper;
using Microsoft.AspNetCore.Components.Web;

public class ProductListItemDTO()
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }

    public class ProductListItemProfile : Profile {
        public ProductListItemProfile()
        {
            CreateMap<Product, ProductListItemDTO>().ForMember(x => x.Title, opt => opt.MapFrom(y => y.Name));
        }
    }
}