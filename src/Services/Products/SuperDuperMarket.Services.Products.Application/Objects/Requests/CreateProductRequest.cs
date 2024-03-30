#nullable disable

namespace SuperDuperMarket.Services.Products.Application.Objects.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public int ProductTypeId { get; set; }

        public int BrandId { get; set; }
    }
}