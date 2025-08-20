using System.ComponentModel.DataAnnotations;

namespace Dmart_web.Core.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int CustomerId { get; set; }

        public List<CartItem> CartItems { get; set; } = new();
    }
}
