using Android.Application.DTOs;
using Android.Application.Interfaces;
using Android.Domain.DbEntities;

namespace Android.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitofWork _unitOfWork;

        public ProductService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name.Trim(),
                Description = dto.Description,
                Price = dto.Price
            };

            await _unitOfWork.ProductRepository
                .CreateAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _unitOfWork.ProductRepository
                .GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository
                .GetByIdAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException(
                    $"Product with ID {id} was not found.");
            }

            return product;
        }

        public async Task<Product> PatchAsync(
            int id,
            ProductPatchDto dto)
        {
            var product = await _unitOfWork.ProductRepository
                .GetByIdForUpdateAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException(
                    $"Product with ID {id} was not found.");
            }

            if (dto.Name != null)
            {
                product.Name = dto.Name.Trim();
            }

            if (dto.Description != null)
            {
                product.Description = dto.Description;
            }

            if (dto.Price.HasValue)
            {
                product.Price = dto.Price.Value;
            }
            product.UpdatedAt = DateTime.Now;
            // No repository Update() required.
            // EF Core is already tracking this entity.

            await _unitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _unitOfWork.ProductRepository
                .DeleteAsync(id);

            if (!deleted)
            {
                throw new KeyNotFoundException(
                    $"Product with ID {id} was not found.");
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

