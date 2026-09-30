using Android.Application.DTOs;
using Android.Domain.DbEntities;

namespace Android.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductCreateDto dto);

        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> PatchAsync(
            int id,
            ProductPatchDto dto);

        Task DeleteAsync(int id);
    }
}
