namespace SuperDuperMarket.Services.Products.Domain;

public class ProductType(string name)
{
    protected internal ProductType(int id, string name)
        : this(name)
    {
        Id = id;
    }

    public int Id { get; protected set; }

    public string Name { get; protected set; } = Throw.IfNullOrWhiteSpace(name);
}

public static class KnownProductTypes
{
    public static readonly ProductType Item = new(1, "Item");
    public static readonly ProductType Service = new(2, "Service");
    public static readonly ProductType Subscription = new(3, "Subscription");

    public static IEnumerable<ProductType> All => [Item, Service, Subscription];
}