using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Repository.Seeds
{
    public class ProductTypeSeed(IRepository<ProductType> repository) : ISeedingService
    {
        protected readonly IRepository<ProductType> repository = Throw.IfNull(repository);

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            foreach (var productType in KnownProductTypes.All)
            {
                if (!await repository.Entities.AnyAsync(productType => productType.Id == productType.Id, cancellationToken))
                {
                    await repository.InsertAsync(productType, cancellationToken);
                }
            }

            await repository.SaveChangesAsync(cancellationToken);
        }
    }
}