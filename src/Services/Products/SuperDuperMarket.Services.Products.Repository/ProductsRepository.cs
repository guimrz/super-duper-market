using SuperDuperMarket.Core.EntityFrameworkCore;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Repository
{
    public class ProductsRepository(ProductsDbContext dbContext) : Repository<Product>(dbContext);
}