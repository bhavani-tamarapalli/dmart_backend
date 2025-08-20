using Microsoft.AspNetCore.Http;

namespace Dmart_web.Core.DTOs
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SubCategoryId { get; set; }
        public IFormFile? ImageFile { get; set; }  
    }
}
