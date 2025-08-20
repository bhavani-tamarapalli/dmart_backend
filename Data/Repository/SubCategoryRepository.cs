//using Dmart_web.Core.Models;
//using Dmart_web.Data.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Repository
//{
//    public class SubCategoryRepository
//    {
//        private readonly DmartContext _context;

//        public SubCategoryRepository(DmartContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<SubCategory>> GetAllAsync()
//        {
//            return await _context.SubCategories.Include(sc => sc.Category).ToListAsync();
//        }

//        public async Task<List<SubCategory>> GetByCategoryAsync(int categoryId)
//        {
//            return await _context.SubCategories
//                .Where(sc => sc.CategoryId == categoryId)
//                .Include(sc => sc.Category)
//                .ToListAsync();
//        }

//        public async Task AddAsync(SubCategory subCategory)
//        {
//            _context.SubCategories.Add(subCategory);
//            await _context.SaveChangesAsync();
//        }
//    }
//}



using Dmart_web.Core.Models;
using Dmart_web.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Data.Repository
{
    public class SubCategoryRepository
    {
        private readonly DmartContext _context;

        public SubCategoryRepository(DmartContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategory>> GetAllAsync()
        {
            return await _context.SubCategories.Include(sc => sc.Category).ToListAsync();
        }

        public async Task<List<SubCategory>> GetByCategoryAsync(int categoryId)
        {
            return await _context.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .Include(sc => sc.Category)
                .ToListAsync();
        }

        //  ADD THIS: GetByIdAsync
        public async Task<SubCategory?> GetByIdAsync(int id)
        {
            return await _context.SubCategories.FindAsync(id);
        }

        public async Task AddAsync(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
        }

        //  ADD THIS: UpdateAsync
        public async Task UpdateAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
        }

        //  ADD THIS: DeleteAsync
        public async Task DeleteAsync(SubCategory subCategory)
        {
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
        }
    }
}
