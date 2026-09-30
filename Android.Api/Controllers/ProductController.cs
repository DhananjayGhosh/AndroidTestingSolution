using Android.Application.DTOs;
using Android.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Android.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProductCreateDto dto)
        {
            var product =
                await _productService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =
                await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product =
                await _productService.GetByIdAsync(id);

            return Ok(product);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(
            [FromRoute] int id,
            [FromBody] ProductPatchDto dto)
        {
            var product =
                await _productService.PatchAsync(id, dto);

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }
    }
}
