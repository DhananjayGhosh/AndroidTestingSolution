namespace Android.Application.Interfaces
{
    public interface IUnitofWork
    {
        IProductRepository ProductRepository { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
