using Android.Application.Interfaces;
using Android.Domain.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Android.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.CreatedAt = DateTime.Now;
            await _context.Set<Product>().AddAsync(product);

            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Set<Product>()
                .AsNoTracking()
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Set<Product>()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByIdForUpdateAsync(int id)
        {
            // IMPORTANT:
            // Don't use AsNoTracking().
            // EF Core will track this entity,
            // allowing PATCH changes to be detected.

            return await _context.Set<Product>()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Set<Product>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Set<Product>().Remove(product);

            return true;
        }
    }
}
