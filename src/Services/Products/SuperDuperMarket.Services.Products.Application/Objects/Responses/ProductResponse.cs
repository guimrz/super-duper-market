#nullable disable

namespace SuperDuperMarket.Services.Products.Application.Objects.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock {  get; set; }

        public int ProductTypeId { get; set; }

        public int BrandId { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }
    }
}