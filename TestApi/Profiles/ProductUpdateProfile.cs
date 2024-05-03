using AutoMapper;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDTO, Product>();
    }
}