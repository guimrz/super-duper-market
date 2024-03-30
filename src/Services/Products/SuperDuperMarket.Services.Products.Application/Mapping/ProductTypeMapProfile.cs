using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Mapping
{
    public class ProductTypeMapProfile : Profile
    {
        public ProductTypeMapProfile()
        {
            CreateMap<ProductType, ProductTypeResponse>();
        }
    }
}