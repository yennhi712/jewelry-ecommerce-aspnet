using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Product
    {

        public long ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        // Thay Category string bằng CategoryID long? để bind dropdown
        [Required(ErrorMessage = "Please specify a category")]
        public long? CategoryID { get; set; }

        // Navigation property EF
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public string? ImageUrl { get; set; }
    }
}
