using Android.Domain.DbEntities;

namespace Android.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);

        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product?> GetByIdForUpdateAsync(int id);

        Task<bool> DeleteAsync(int id);
    }
}
