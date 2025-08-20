//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;


//namespace Dmart_web.Data.Repository
//{
//    public class CategoryRepository
//    {
//        private readonly DmartContext _context;

//        public CategoryRepository(DmartContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Category>> GetAllAsync()
//        {
//            return await _context.Categories.Include(c => c.SubCategories).ToListAsync();
//        }

//        public async Task<Category?> GetByIdAsync(int id)
//        {
//            return await _context.Categories.FindAsync(id);
//        }


//        public async Task AddAsync(Category category)
//        {
//            _context.Categories.Add(category);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Category category)
//        {
//            _context.Categories.Update(category);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(Category category)
//        {
//            _context.Categories.Remove(category);
//            await _context.SaveChangesAsync();
//        }

//    }
//}


//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Repository
//{
//    public class CategoryRepository
//    {
//        private readonly DmartContext _context;

//        public CategoryRepository(DmartContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Category>> GetAllAsync()
//        {
//            return await _context.Categories
//                .Include(c => c.SubCategories)
//                    .ThenInclude(sc => sc.Products)
//                .ToListAsync();
//        }

//        public async Task<Category?> GetByIdAsync(int id)
//        {
//            return await _context.Categories
//                .Include(c => c.SubCategories)
//                    .ThenInclude(sc => sc.Products)
//                .FirstOrDefaultAsync(c => c.CategoryId == id);
//        }

//        public async Task AddAsync(Category category)
//        {
//            _context.Categories.Add(category);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Category category)
//        {
//            _context.Categories.Update(category);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(Category category)
//        {
//            _context.Categories.Remove(category);
//            await _context.SaveChangesAsync();
//        }
//    }
//}


using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Data.Repository
{
    public class CategoryRepository
    {
        private readonly DmartContext _context;

        public CategoryRepository(DmartContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.SubCategories)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // New: load category with subcategories (no product includes)
        public async Task<Category?> GetByIdWithSubCategoriesAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.SubCategories)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
