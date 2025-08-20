using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{customerId}")]
        //public async Task<IActionResult> GetCart(int customerId)
        //{
        //    var cart = await _cartService.GetCartAsync(customerId);
        //    return Ok(cart);
        //}

        public async Task<IActionResult> GetCart(int customerId)
        {
            try
            {
                var cart = await _cartService.GetCartAsync(customerId);

                if (cart == null || cart.Items == null || !cart.Items.Any())
                {
                    return Ok(new List<CartItemDTO>()); // Return empty array for consistency
                }

                return Ok(cart.Items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to retrieve cart", error = ex.Message });
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromQuery] int customerId, [FromQuery] int productId, [FromQuery] int quantity)
        {
            await _cartService.AddToCartAsync(customerId, productId, quantity);
            return Ok(new { message = "Item added to cart successfully!" });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItem([FromQuery] int customerId, [FromQuery] int productId, [FromQuery] int quantity)
        {
            try
            {
                await _cartService.UpdateCartItemQuantityAsync(customerId, productId, quantity);
                return Ok(new { message = "Cart item updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update cart item", error = ex.Message });
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromQuery] int customerId, [FromQuery] int productId)
        {
            try
            {
                await _cartService.RemoveFromCartAsync(customerId, productId);
                return Ok(new { message = "Item removed from cart successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to remove item from cart", error = ex.Message });
            }
        }

        [HttpDelete("clear/{customerId}")]
        public async Task<IActionResult> ClearCart(int customerId)
        {
            try
            {
                await _cartService.ClearCartAsync(customerId);
                return Ok(new { message = "Cart cleared successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to clear cart", error = ex.Message });
            }
        }
    }
}
