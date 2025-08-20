namespace Dmart_web.Core.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }  

        public decimal OriginalPrice { get; set; } 

        public decimal? DiscountPrice { get; set; }  

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        public byte[]? Image { get; set; }

        public int Variant { get; set; }

        public int SubCategoryId { get; set; }

       
    }
}
