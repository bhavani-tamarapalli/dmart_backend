namespace Dmart_web.Core.DTOs
{
    public class ProductSearchDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Calculated property for savings percentage
        public decimal SavingsPercentage => OriginalPrice > 0
            ? Math.Round(((OriginalPrice - Price) / OriginalPrice) * 100, 1)
            : 0;

    }
}
