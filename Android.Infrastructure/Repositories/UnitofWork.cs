using Android.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Android.Infrastructure.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductRepository ProductRepository { get; }

        public UnitofWork(ApplicationDbContext dbContext, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
        }
        

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(
            cancellationToken);
        }
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
