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

//        public async Task<SubCategory?> GetByIdAsync(int id)
//        {
//            return await _context.SubCategories.FindAsync(id);
//        }

//        public async Task AddAsync(SubCategory subCategory)
//        {
//            _context.SubCategories.Add(subCategory);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(SubCategory subCategory)
//        {
//            _context.SubCategories.Update(subCategory);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(SubCategory subCategory)
//        {
//            _context.SubCategories.Remove(subCategory);
//            await _context.SaveChangesAsync();
//        }
//    }
//}

using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Repository;

namespace Dmart_web.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly SubCategoryRepository _repo;

        public SubCategoryService(SubCategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SubCategory>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<SubCategory>> GetByCategoryAsync(int categoryId)
        {
            return await _repo.GetByCategoryAsync(categoryId);
        }

        public async Task<string> AddAsync(SubCategoryDTO dto)
        {
            var subCategory = new SubCategory
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId
            };

            await _repo.AddAsync(subCategory);
            return "SubCategory added successfully";
        }

        public async Task<bool> UpdateAsync(int id, SubCategoryDTO dto)
        {
            var subCategory = await _repo.GetByIdAsync(id); // ✅ Corrected line
            if (subCategory == null)
                return false;

            subCategory.Name = dto.Name;
            subCategory.CategoryId = dto.CategoryId;

            await _repo.UpdateAsync(subCategory);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subCategory = await _repo.GetByIdAsync(id);
            if (subCategory == null)
                return false;

            await _repo.DeleteAsync(subCategory);
            return true;
        }
    }
}
