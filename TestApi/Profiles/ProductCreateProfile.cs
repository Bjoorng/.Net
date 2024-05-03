using AutoMapper;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDTO, Product>();
    }
}