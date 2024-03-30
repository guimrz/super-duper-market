using Microsoft.Extensions.DependencyInjection;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;

namespace SuperDuperMarket.Core.EntityFrameworkCore
{
    public class RepositoryProvider(IServiceProvider serviceProvider) : IRepositoryProvider
    {
        protected readonly IServiceProvider serviceProvider = Throw.IfNull(serviceProvider);

        public IRepository<T> GetRepository<T>() where T : class
        {
            return serviceProvider.GetRequiredService<IRepository<T>>();
        }
    }
}