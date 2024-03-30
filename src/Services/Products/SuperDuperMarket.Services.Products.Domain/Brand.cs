namespace SuperDuperMarket.Services.Products.Domain
{
    public class Brand(string name)
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; } = Throw.IfNullOrWhiteSpace(name);
    }
}