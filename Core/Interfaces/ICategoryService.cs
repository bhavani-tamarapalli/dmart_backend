//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Models;


//namespace Dmart_web.Core.Interfaces
//{
//    public interface ICategoryService
//    {
//        Task<List<Category>> GetAllAsync();
//        Task<Category> GetByIdAsync(int id);
//        Task<string> AddAsync(CategoryDTO dto);
//        Task<bool>UpdateAsync(int id,CategoryDTO dto);
//        Task<bool> DeleteAsync(int id);


//    }
//}

using Dmart_web.Core.DTOs;
using Dmart_web.Core.Models;

namespace Dmart_web.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<List<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId);
        Task<string> AddAsync(CategoryDTO dto);
        Task<bool> UpdateAsync(int id, CategoryDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
