
/*
using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Dmart_web.Data.Repository;

namespace Dmart_web.Service
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;
        private readonly ProductRepository _productRepository;
        private readonly DmartContext _context;

        public CartService(CartRepository cartRepository, ProductRepository productRepository, DmartContext context)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<CartDTO> GetCartAsync(int customerId)
        {
            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);

            if (cart == null)
            {
                cart = new Cart { CustomerId = customerId };
                await _cartRepository.AddAsync(cart);
            }

            return new CartDTO
            {
                CartId = cart.CartId,
                CustomerId = cart.CustomerId,
                Items = cart.CartItems?.Select(ci => new CartItemDTO
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.ProductName,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity,
                    ImageUrl = ci.Product.ImageUrl
                }).ToList() ?? new List<CartItemDTO>()
            };
        }

        public async Task AddToCartAsync(int customerId, int productId, int quantity)
        {
            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);

            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId = customerId,
                    CartItems = new List<CartItem>()
                };
                await _cartRepository.AddAsync(cart);
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null) return;

                var newItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.CartId
                };

                cart.CartItems.Add(newItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCartItemAsync(int cartItemId, int quantity)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null) return;

            cartItem.Quantity = quantity;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null) return;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
*/

using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Dmart_web.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Service
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;
        private readonly ProductRepository _productRepository;
        private readonly DmartContext _context;

        public CartService(CartRepository cartRepository, ProductRepository productRepository, DmartContext context)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<CartDTO> GetCartAsync(int customerId)
        {
            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);

            if (cart == null)
            {
                cart = new Cart { CustomerId = customerId, CartItems = new List<CartItem>() };
                await _cartRepository.AddAsync(cart);
            }

            return new CartDTO
            {
                CartId = cart.CartId,
                CustomerId = cart.CustomerId,
                Items = cart.CartItems?.Select(ci => new CartItemDTO
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.ProductName,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity,
                    Image = ci.Product.Image


                }).ToList() ?? new List<CartItemDTO>()
            };
        }

        public async Task AddToCartAsync(int customerId, int productId, int quantity)
        {
            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);

            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId = customerId,
                    CartItems = new List<CartItem>()
                };
                await _cartRepository.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null) return;

                var newItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.CartId
                };

                cart.CartItems.Add(newItem);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task UpdateCartItemAsync(int cartItemId, int quantity)
        //{
        //    var cartItem = await _context.CartItems.FindAsync(cartItemId);
        //    if (cartItem == null) return;

        //    cartItem.Quantity = quantity;
        //    await _context.SaveChangesAsync();
        //}

        public async Task UpdateCartItemQuantityAsync(int customerId, int productId, int quantity)
        {
            if (quantity <= 0)
            {
                await RemoveFromCartAsync(customerId, productId);
                return;
            }

            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);
            if (cart == null) return;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null) return;

            cartItem.Quantity = quantity;
            await _context.SaveChangesAsync();
        }

        //public async Task RemoveCartItemAsync(int cartItemId)
        //{
        //    var cartItem = await _context.CartItems.FindAsync(cartItemId);
        //    if (cartItem == null) return;

        //    _context.CartItems.Remove(cartItem);
        //    await _context.SaveChangesAsync();
        //}

        public async Task RemoveFromCartAsync(int customerId, int productId)
        {
            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);
            if (cart == null) return;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null) return;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task ClearCartAsync(int customerId)
        {
            var cart = await _cartRepository.GetCartWithItemsAsync(customerId);
            if (cart == null) return;

            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();
        }
    }
}
