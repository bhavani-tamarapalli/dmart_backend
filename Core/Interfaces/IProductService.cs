
/*
using Dmart_web.Core.DTOs;

namespace Dmart_web.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task AddProductAsync(ProductDTO productDto);
        Task UpdateProductAsync(ProductDTO productDto);
        Task DeleteProductAsync(int productId);
    }
}
*/

//using Dmart_web.Core.DTOs;
//using Microsoft.AspNetCore.Http;

//namespace Dmart_web.Core.Interfaces
//{
//    public interface IProductService
//    {
//        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
//        Task<ProductDTO?> GetProductByIdAsync(int productId);

//        Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);
//        Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryIdAsync(int subCategoryId);
//        Task AddProductAsync(ProductDTO productDto, IFormFile? imageFile);
//        Task UpdateProductAsync(ProductDTO productDto, IFormFile? imageFile);
//        Task DeleteProductAsync(int productId);
//    }
//}

using Dmart_web.Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace Dmart_web.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int productId);

        Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryIdAsync(int subCategoryId);

        Task AddProductAsync(ProductDTO productDto, IFormFile? imageFile);
        Task UpdateProductAsync(ProductDTO productDto, IFormFile? imageFile);
        Task DeleteProductAsync(int productId);


        //for search
        Task<SearchResultDTO> SearchProductsAsync(string query, int page = 1, int pageSize = 20);
        Task<List<string>> GetSearchSuggestionsAsync(string partialQuery, int maxSuggestions = 10);
    }
}
