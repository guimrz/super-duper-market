#nullable disable

namespace SuperDuperMarket.Services.Products.Application.Objects.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }
    }
}