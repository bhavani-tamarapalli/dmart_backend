using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dmart_web.Core.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        public byte[]? Image { get; set; }

        public int SubCategoryId { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }
    }
}






       

    