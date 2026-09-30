using System.ComponentModel.DataAnnotations;

namespace Android.Application.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(typeof(decimal), "0.01", "999999999")]
        public decimal Price { get; set; }
    }
}
