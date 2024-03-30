namespace SuperDuperMarket.Core.EntityFrameworkCore.Abstractions
{
    public interface IRepositoryProvider
    {
        IRepository<T> GetRepository<T>() where T : class;
    }
}