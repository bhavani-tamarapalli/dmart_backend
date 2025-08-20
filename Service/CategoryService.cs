//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Repository;

//namespace Dmart_web.Service
//{
//    public class CategoryService : ICategoryService
//    {
//        private readonly CategoryRepository _repo;

//        public CategoryService(CategoryRepository repo)
//        {
//            _repo = repo;
//        }

//        public async Task<List<Category>> GetAllAsync()
//        {
//            return await _repo.GetAllAsync();
//        }

//        public async Task<Category?> GetByIdAsync(int id)
//        {
//            return await _repo.GetByIdAsync(id);
//        }



//        public async Task<string> AddAsync(CategoryDTO dto)
//        {
//            var category = new Category { Name = dto.Name };
//            await _repo.AddAsync(category);
//            return "Category added successfully";
//        }

//        public async Task<bool> UpdateAsync(int id, CategoryDTO dto)
//        {
//            var category = await _repo.GetByIdAsync(id);
//            if (category == null) return false;

//            category.Name = dto.Name;
//            await _repo.UpdateAsync(category);
//            return true;
//        }


//        public async Task<bool> DeleteAsync(int id)
//        {
//            var category = await _repo.GetByIdAsync(id);
//            if (category == null) return false;

//            await _repo.DeleteAsync(category);
//            return true;
//        }
//    }
//}


//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Repository;

//namespace Dmart_web.Service
//{
//    public class CategoryService : ICategoryService
//    {
//        private readonly CategoryRepository _repo;

//        public CategoryService(CategoryRepository repo)
//        {
//            _repo = repo;
//        }

//        public async Task<List<Category>> GetAllAsync()
//        {
//            return await _repo.GetAllAsync();
//        }

//        public async Task<Category?> GetByIdAsync(int id)
//        {
//            return await _repo.GetByIdAsync(id);
//        }

//        public async Task<string> AddAsync(CategoryDTO dto)
//        {
//            var category = new Category { Name = dto.Name };
//            await _repo.AddAsync(category);
//            return "Category added successfully";
//        }

//        public async Task<bool> UpdateAsync(int id, CategoryDTO dto)
//        {
//            var category = await _repo.GetByIdAsync(id);
//            if (category == null) return false;

//            category.Name = dto.Name;
//            await _repo.UpdateAsync(category);
//            return true;
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var category = await _repo.GetByIdAsync(id);
//            if (category == null) return false;

//            await _repo.DeleteAsync(category);
//            return true;
//        }
//    }
//}


using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Repository;

namespace Dmart_web.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _repo;

        public CategoryService(CategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // New: return SubCategories for a category id
        public async Task<List<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId)
        {
            var category = await _repo.GetByIdWithSubCategoriesAsync(categoryId);
            return category?.SubCategories?.ToList() ?? new List<SubCategory>();
        }

        public async Task<string> AddAsync(CategoryDTO dto)
        {
            var category = new Category { Name = dto.Name };
            await _repo.AddAsync(category);
            return "Category added successfully";
        }

        public async Task<bool> UpdateAsync(int id, CategoryDTO dto)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return false;

            category.Name = dto.Name;
            await _repo.UpdateAsync(category);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return false;

            await _repo.DeleteAsync(category);
            return true;
        }
    }
}
