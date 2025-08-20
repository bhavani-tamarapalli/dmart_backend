using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Data.Repository
{
    public class CartRepository : BaseRepository<Cart>
    {
        private readonly DmartContext _context;

        public CartRepository(DmartContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartWithItemsAsync(int customerId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
