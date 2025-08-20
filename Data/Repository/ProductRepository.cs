
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;
//namespace Dmart_web.Data.Repository
//{
//    public class ProductRepository : BaseRepository<Product>
//    {
//        private readonly DmartContext _context;

//        public ProductRepository(DmartContext context) : base(context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Product>> GetAllWithSubCategoryAsync()
//        {
//            return await _context.Products
//                .Include(p => p.SubCategory)
//                .ToListAsync();
//        }

//        public async Task<Product?> GetByIdWithSubCategoryAsync(int id)
//        {
//            return await _context.Products
//                .Include(p => p.SubCategory)
//                .FirstOrDefaultAsync(p => p.ProductId == id);
//        }
//    }
//}
using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Data.Repository
{
    public class ProductRepository
    {
        private readonly DmartContext _context;

        public ProductRepository(DmartContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllWithSubCategoryAsync()
        {
            return await _context.Products
                .Include(p => p.SubCategory)
                .ThenInclude(sc => sc.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.SubCategory)
                .ThenInclude(sc => sc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        // New: products filtered by category id (via subcategories)
        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var subIds = await _context.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .Select(sc => sc.SubCategoryId)
                .ToListAsync();

            if (subIds.Count == 0) return new List<Product>();

            return await _context.Products
                .Where(p => subIds.Contains(p.SubCategoryId))
                .Include(p => p.SubCategory)
                .AsNoTracking()
                .ToListAsync();
        }

        // New: products filtered by subcategory id
        public async Task<List<Product>> GetProductsBySubCategoryIdAsync(int subCategoryId)
        {
            return await _context.Products
                .Where(p => p.SubCategoryId == subCategoryId)
                .Include(p => p.SubCategory)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
