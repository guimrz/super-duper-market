using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Mapping
{
    public class BrandMapProfile : Profile
    {
        public BrandMapProfile()
        {
            CreateMap<Brand, BrandResponse>();
        }
    }
}