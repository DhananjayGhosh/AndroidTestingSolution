using System.ComponentModel.DataAnnotations;

namespace Android.Application.DTOs
{
    public class ProductPatchDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Range(typeof(decimal), "0.01", "999999999")]
        public decimal? Price { get; set; }
    }
}
