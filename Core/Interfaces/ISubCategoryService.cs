using Dmart_web.Core.DTOs;
using Dmart_web.Core.Models;

namespace Dmart_web.Core.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetAllAsync();
        Task<List<SubCategory>> GetByCategoryAsync(int categoryId);
        Task<string> AddAsync(SubCategoryDTO dto);
        Task<bool> UpdateAsync(int id ,SubCategoryDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
