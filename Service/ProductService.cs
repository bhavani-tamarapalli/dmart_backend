
/*
using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Repository;

namespace Dmart_web.Service
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllWithSubCategoryAsync();

            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            });
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                Description = "", // You can extend DTO to include description
                SubCategoryId = 1 // Hardcoded; Update as per requirement
            };

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.ProductId);
            if (product == null) return;

            product.ProductName = productDto.ProductName;
            product.Price = productDto.Price;
            product.ImageUrl = productDto.ImageUrl;

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return;

            await _productRepository.DeleteAsync(product);
        }
    }
}
*/

//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Repository;
//using Microsoft.AspNetCore.Http;

//namespace Dmart_web.Service
//{
//    public class ProductService : IProductService
//    {
//        private readonly ProductRepository _productRepository;

//        public ProductService(ProductRepository productRepository)
//        {
//            _productRepository = productRepository;
//        }

//        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
//        {
//            var products = await _productRepository.GetAllWithSubCategoryAsync();

//            return products.Select(p => new ProductDTO
//            {
//                ProductId = p.ProductId,
//                ProductName = p.ProductName,
//                Description = p.Description,
//                OriginalPrice = p.OriginalPrice,
//                DiscountPrice = p.DiscountPrice,
//                Price = p.Price,
//                IsAvailable = p.IsAvailable,
//                Image = p.Image, //  byte[] instead of URL
//                SubCategoryId = p.SubCategoryId
//            });
//        }

//        public async Task<ProductDTO?> GetProductByIdAsync(int productId)
//        {
//            var product = await _productRepository.GetByIdAsync(productId);
//            if (product == null) return null;

//            return new ProductDTO
//            {
//                ProductId = product.ProductId,
//                ProductName = product.ProductName,
//                Description = product.Description,
//                OriginalPrice = product.OriginalPrice,
//                DiscountPrice = product.DiscountPrice,
//                Price = product.Price,
//                IsAvailable = product.IsAvailable,
//                Image = product.Image,
//                SubCategoryId = product.SubCategoryId
//            };
//        }

//        public async Task AddProductAsync(ProductDTO productDto, IFormFile? imageFile)
//        {
//            byte[]? imageData = null;

//            if (imageFile != null && imageFile.Length > 0)
//            {
//                using var ms = new MemoryStream();
//                await imageFile.CopyToAsync(ms);
//                imageData = ms.ToArray(); //  FIXED (use imageData instead of product.Image)
//            }

//            var product = new Product
//            {
//                ProductName = productDto.ProductName,
//                Description = productDto.Description,
//                OriginalPrice = productDto.OriginalPrice,
//                DiscountPrice = productDto.DiscountPrice,
//                Price = productDto.Price,
//                IsAvailable = productDto.IsAvailable,
//                Image = imageData,
//                SubCategoryId = productDto.SubCategoryId
//            };

//            await _productRepository.AddAsync(product);
//        }

//        public async Task UpdateProductAsync(ProductDTO productDto, IFormFile? imageFile)
//        {
//            var product = await _productRepository.GetByIdAsync(productDto.ProductId);
//            if (product == null) return;

//            product.ProductName = productDto.ProductName;
//            product.Description = productDto.Description;
//            product.OriginalPrice = productDto.OriginalPrice;
//            product.DiscountPrice = productDto.DiscountPrice;
//            product.Price = productDto.Price;
//            product.IsAvailable = productDto.IsAvailable;
//            product.SubCategoryId = productDto.SubCategoryId;

//            if (imageFile != null && imageFile.Length > 0)
//            {
//                using var ms = new MemoryStream();
//                await imageFile.CopyToAsync(ms);
//                product.Image = ms.ToArray();
//            }

//            await _productRepository.UpdateAsync(product);
//        }

//        public async Task DeleteProductAsync(int productId)
//        {
//            var product = await _productRepository.GetByIdAsync(productId);
//            if (product == null) return;

//            await _productRepository.DeleteAsync(product);
//        }
//    }
//}



//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Core.Models;
//using Dmart_web.Data.Repository;
//using Microsoft.AspNetCore.Http;

//namespace Dmart_web.Service
//{
//    public class ProductService : IProductService
//    {
//        private readonly ProductRepository _productRepository;

//        public ProductService(ProductRepository productRepository)
//        {
//            _productRepository = productRepository;
//        }

//        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
//        {
//            var products = await _productRepository.GetAllWithSubCategoryAsync();

//            return products.Select(p => new ProductDTO
//            {
//                ProductId = p.ProductId,
//                ProductName = p.ProductName,
//                Description = p.Description,
//                OriginalPrice = p.OriginalPrice,
//                DiscountPrice = p.DiscountPrice,
//                Price = p.Price,
//                IsAvailable = p.IsAvailable,
//                Image = p.Image, // byte[]
//                SubCategoryId = p.SubCategoryId
//            });
//        }

//        public async Task<ProductDTO?> GetProductByIdAsync(int productId)
//        {
//            var product = await _productRepository.GetByIdAsync(productId);
//            if (product == null) return null;

//            return new ProductDTO
//            {
//                ProductId = product.ProductId,
//                ProductName = product.ProductName,
//                Description = product.Description,
//                OriginalPrice = product.OriginalPrice,
//                DiscountPrice = product.DiscountPrice,
//                Price = product.Price,
//                IsAvailable = product.IsAvailable,
//                Image = product.Image,
//                SubCategoryId = product.SubCategoryId
//            };
//        }

//        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
//        {
//            var products = await _productRepository.GetProductsByCategoryIdAsync(categoryId);
//            return products.Select(p => new ProductDTO
//            {
//                ProductId = p.ProductId,
//                ProductName = p.ProductName,
//                Description = p.Description,
//                OriginalPrice = p.OriginalPrice,
//                DiscountPrice = p.DiscountPrice,
//                Price = p.Price,
//                IsAvailable = p.IsAvailable,
//                Image = p.Image,
//                SubCategoryId = p.SubCategoryId
//            });
//        }

//        public async Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryIdAsync(int subCategoryId)
//        {
//            var products = await _productRepository.GetProductsBySubCategoryIdAsync(subCategoryId);
//            return products.Select(p => new ProductDTO
//            {
//                ProductId = p.ProductId,
//                ProductName = p.ProductName,
//                Description = p.Description,
//                OriginalPrice = p.OriginalPrice,
//                DiscountPrice = p.DiscountPrice,
//                Price = p.Price,
//                IsAvailable = p.IsAvailable,
//                Image = p.Image,
//                SubCategoryId = p.SubCategoryId
//            });
//        }

//        public async Task AddProductAsync(ProductDTO productDto, IFormFile? imageFile)
//        {
//            byte[]? imageData = null;
//            if (imageFile != null && imageFile.Length > 0)
//            {
//                using var ms = new MemoryStream();
//                await imageFile.CopyToAsync(ms);
//                imageData = ms.ToArray();
//            }

//            var product = new Product
//            {
//                ProductName = productDto.ProductName,
//                Description = productDto.Description,
//                OriginalPrice = productDto.OriginalPrice,
//                DiscountPrice = productDto.DiscountPrice,
//                Price = productDto.Price,
//                IsAvailable = productDto.IsAvailable,
//                Image = imageData,
//                SubCategoryId = productDto.SubCategoryId
//            };

//            await _productRepository.AddAsync(product);
//        }

//        public async Task UpdateProductAsync(ProductDTO productDto, IFormFile? imageFile)
//        {
//            var product = await _productRepository.GetByIdAsync(productDto.ProductId);
//            if (product == null) return;

//            product.ProductName = productDto.ProductName;
//            product.Description = productDto.Description;
//            product.OriginalPrice = productDto.OriginalPrice;
//            product.DiscountPrice = productDto.DiscountPrice;
//            product.Price = productDto.Price;
//            product.IsAvailable = productDto.IsAvailable;
//            product.SubCategoryId = productDto.SubCategoryId;

//            if (imageFile != null && imageFile.Length > 0)
//            {
//                using var ms = new MemoryStream();
//                await imageFile.CopyToAsync(ms);
//                product.Image = ms.ToArray();
//            }

//            await _productRepository.UpdateAsync(product);
//        }

//        public async Task DeleteProductAsync(int productId)
//        {
//            var product = await _productRepository.GetByIdAsync(productId);
//            if (product == null) return;

//            await _productRepository.DeleteAsync(product);
//        }


//        //search

//        public async Task<SearchResultDTO> SearchProductsAsync(string query, int page = 1, int pageSize = 20)
//        {
//            var allProducts = await _productRepository.GetAllWithCategoryAsync(); // Use a repository method that fetches category data.

//            // Case-insensitive search on product name, description, category, and brand
//            var filteredProducts = allProducts
//                .Where(p =>
//                    p.ProductName.ToLower().Contains(query.ToLower()) ||
//                    (p.Description != null && p.Description.ToLower().Contains(query.ToLower())) ||
//                    (p.SubCategory != null && p.SubCategory.SubCategoryName.ToLower().Contains(query.ToLower())) ||
//                    (p.SubCategory != null && p.SubCategory.Category.CategoryName.ToLower().Contains(query.ToLower()))
//                )
//                .ToList();

//            var totalCount = filteredProducts.Count;
//            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

//            var paginatedProducts = filteredProducts
//                .Skip((page - 1) * pageSize)
//                .Take(pageSize)
//                .ToList();

//            var productSearchDTOs = paginatedProducts.Select(p => new ProductSearchDTO
//            {
//                ProductId = p.ProductId,
//                ProductName = p.ProductName,
//                Price = p.Price,
//                OriginalPrice = p.OriginalPrice,
//                DiscountPrice = p.DiscountPrice,
//                Description = p.Description,
//                Image = p.Image,
//                Category = p.SubCategory?.Category?.CategoryName,
//                Brand = null, // Assuming Brand is not available in the model
//                IsAvailable = p.IsAvailable
//            }).ToList();

//            return new SearchResultDTO
//            {
//                Products = productSearchDTOs,
//                TotalCount = totalCount,
//                CurrentPage = page,
//                PageSize = pageSize,
//                TotalPages = totalPages,
//                SearchQuery = query,
//                Message = totalCount > 0 ? "Products found" : "No products found"
//            };
//        }

//        public async Task<List<string>> GetSearchSuggestionsAsync(string partialQuery, int maxSuggestions = 10)
//        {
//            var allProducts = await _productRepository.GetAllAsync();

//            var suggestions = allProducts
//                .Where(p => p.ProductName.ToLower().Contains(partialQuery.ToLower()))
//                .Select(p => p.ProductName)
//                .Distinct()
//                .OrderBy(s => s)
//                .Take(maxSuggestions)
//                .ToList();

//            return suggestions;
//        }
//    }
//}


using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Dmart_web.Core.Models;
using Dmart_web.Data.Repository;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Dmart_web.Service
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllWithSubCategoryAsync();

            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                OriginalPrice = p.OriginalPrice,
                DiscountPrice = p.DiscountPrice,
                Price = p.Price,
                IsAvailable = p.IsAvailable,
                Image = p.Image,
                SubCategoryId = p.SubCategoryId
            });
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                OriginalPrice = product.OriginalPrice,
                DiscountPrice = product.DiscountPrice,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                Image = product.Image,
                SubCategoryId = product.SubCategoryId
            };
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryIdAsync(categoryId);
            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                OriginalPrice = p.OriginalPrice,
                DiscountPrice = p.DiscountPrice,
                Price = p.Price,
                IsAvailable = p.IsAvailable,
                Image = p.Image,
                SubCategoryId = p.SubCategoryId
            });
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryIdAsync(int subCategoryId)
        {
            var products = await _productRepository.GetProductsBySubCategoryIdAsync(subCategoryId);
            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                OriginalPrice = p.OriginalPrice,
                DiscountPrice = p.DiscountPrice,
                Price = p.Price,
                IsAvailable = p.IsAvailable,
                Image = p.Image,
                SubCategoryId = p.SubCategoryId
            });
        }

        public async Task AddProductAsync(ProductDTO productDto, IFormFile? imageFile)
        {
            byte[]? imageData = null;
            if (imageFile != null && imageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await imageFile.CopyToAsync(ms);
                imageData = ms.ToArray();
            }

            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                OriginalPrice = productDto.OriginalPrice,
                DiscountPrice = productDto.DiscountPrice,
                Price = productDto.Price,
                IsAvailable = productDto.IsAvailable,
                Image = imageData,
                SubCategoryId = productDto.SubCategoryId
            };

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDto, IFormFile? imageFile)
        {
            var product = await _productRepository.GetByIdAsync(productDto.ProductId);
            if (product == null) return;

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.OriginalPrice = productDto.OriginalPrice;
            product.DiscountPrice = productDto.DiscountPrice;
            product.Price = productDto.Price;
            product.IsAvailable = productDto.IsAvailable;
            product.SubCategoryId = productDto.SubCategoryId;

            if (imageFile != null && imageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await imageFile.CopyToAsync(ms);
                product.Image = ms.ToArray();
            }

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return;

            await _productRepository.DeleteAsync(product);
        }

        public async Task<SearchResultDTO> SearchProductsAsync(string query, int page = 1, int pageSize = 20)
        {
            var allProducts = await _productRepository.GetAllWithSubCategoryAsync();
            var sanitizedQuery = query.Trim().ToLower();

            var matchingProducts = allProducts
                .Where(p => p.ProductName.ToLower().Contains(sanitizedQuery) ||
                            (p.Description != null && p.Description.ToLower().Contains(sanitizedQuery)))
                .ToList();

            var totalCount = matchingProducts.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var paginatedProducts = matchingProducts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var productDtos = paginatedProducts.Select(p => new ProductSearchDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                //OriginalPrice = p.OriginalPrice ?? 0m, // Corrected line
                //DiscountPrice = p.DiscountPrice,
                Image = p.Image,
                //Category = p.SubCategory?.Category?.CategoryName, // Corrected line
                Brand = null,
                IsAvailable = p.IsAvailable
            }).ToList();

            return new SearchResultDTO
            {
                Products = productDtos,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                SearchQuery = query,
                Message = totalCount > 0 ? "Search results found" : "No products found"
            };
        }

        public async Task<List<string>> GetSearchSuggestionsAsync(string partialQuery, int maxSuggestions = 10)
        {
            // Corrected to use GetAllWithSubCategoryAsync
            var allProducts = await _productRepository.GetAllWithSubCategoryAsync();
            var sanitizedQuery = partialQuery.Trim().ToLower();

            var suggestions = allProducts
                .Where(p => p.ProductName.ToLower().Contains(sanitizedQuery))
                .Select(p => p.ProductName)
                .Distinct()
                .Take(maxSuggestions)
                .ToList();

            return suggestions;
        }
    }
}