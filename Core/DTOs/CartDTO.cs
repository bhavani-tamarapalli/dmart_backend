namespace Dmart_web.Core.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }

        public List<CartItemDTO> Items { get; set; }
    }
}
