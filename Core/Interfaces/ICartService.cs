using Dmart_web.Core.DTOs;

namespace Dmart_web.Core.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> GetCartAsync(int customerId);
        Task AddToCartAsync(int customerId, int productId, int quantity);
        //Task UpdateCartItemAsync(int cartItemId, int quantity);
        Task UpdateCartItemQuantityAsync(int customerId, int productId, int quantity);
        //Task RemoveCartItemAsync(int cartItemId);

        Task RemoveFromCartAsync(int customerId, int productId);

        Task ClearCartAsync(int customerId);
    }
}
