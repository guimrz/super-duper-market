namespace SuperDuperMarket.Services.Products.Domain
{
    public class Product
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; } = default!;

        public string? Description { get; set; }

        public int Stock { get; protected set; }

        public virtual Brand Brand { get; protected set; } = default!;

        public int BrandId { get; protected set; }

        public virtual ProductType ProductType { get; protected set; } = default!;

        public int ProductTypeId { get; protected set; }

        public DateTimeOffset CreationDate { get; protected set; }

        public DateTimeOffset? UpdateDate { get; protected set; } = null;

        protected Product()
        {
            //
        }

        public Product(string name, string? description, int stock, Brand brand, ProductType productType)
        {
            Description = description;
            Stock = stock;
            Name = Throw.IfNullOrWhiteSpace(name);
            Brand = Throw.IfNull(brand);
            ProductType = Throw.IfNull(productType);
        }
    }
}