using SuperDuperMarket.Core;

namespace SuperDuperMarket.Services.Products.Domain
{
    public class Product(string name)
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public string Name { get; protected set; } = Throw.IfNullOrWhiteSpace(name);

        public DateTimeOffset CreationDate { get; protected set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? UpdateDate { get; protected set; } = null;
    }
}