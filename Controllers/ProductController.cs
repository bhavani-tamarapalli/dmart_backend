
/*
using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDto)
        {
            await _productService.AddProductAsync(productDto);
            return Ok(new { message = "Product added successfully!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            productDto.ProductId = id;
            await _productService.UpdateProductAsync(productDto);
            return Ok(new { message = "Product updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Product deleted successfully!" });
        }
    }
}
*/


/*
//sending the image using post method
using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductDTO productDto, IFormFile? imageFile)
        {
            await _productService.AddProductAsync(productDto, imageFile);
            return Ok(new { message = "Product added successfully!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDTO productDto, IFormFile? imageFile)
        {
            productDto.ProductId = id;
            await _productService.UpdateProductAsync(productDto, imageFile);
            return Ok(new { message = "Product updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Product deleted successfully!" });
        }
    }
}
*/


//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Dmart_web.Controllers
//{
//    //[Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _productService;

//        public ProductController(IProductService productService)
//        {
//            _productService = productService;
//        }

//        //  Get all products
//        [HttpGet]
//        public async Task<IActionResult> GetAllProducts()
//        {
//            var products = await _productService.GetAllProductsAsync();
//            return Ok(products);
//        }

//        //  Get product by Id (including image in base64 or byte[])
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProductById(int id)
//        {
//            var product = await _productService.GetProductByIdAsync(id);
//            if (product == null) return NotFound();
//            return Ok(product);
//        }

//        //  Get only product image by productId
//        [HttpGet("{id}/image")]
//        public async Task<IActionResult> GetProductImage(int id)
//        {
//            var product = await _productService.GetProductByIdAsync(id);
//            if (product == null || product.Image == null) return NotFound();

//            return File(product.Image, "image/jpeg");
//            // If you store PNG: use "image/png"
//        }

//        //  Add product (upload image using form-data)
//        [HttpPost]
//        [Consumes("multipart/form-data")] //   for Swagger to handle form-data
//        public async Task<IActionResult> AddProduct([FromForm] ProductCreateDTO productDto)
//        {
//            //  Map to existing ProductDTO + IFormFile
//            var dto = new ProductDTO
//            {
//                ProductName = productDto.ProductName,
//                Description = productDto.Description,
//                OriginalPrice = productDto.OriginalPrice,
//                DiscountPrice = productDto.DiscountPrice,
//                Price = productDto.Price,
//                IsAvailable = productDto.IsAvailable,
//                SubCategoryId = productDto.SubCategoryId
//            };

//            await _productService.AddProductAsync(dto, productDto.ImageFile);

//            return Ok(new { message = "Product added successfully!" });
//        }


//        // Update product (update image also using form-data)
//        [HttpPut("{id}")]
//        [Consumes("multipart/form-data")]
//        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductUpdateDTO productDto)
//        {
//            var dto = new ProductDTO
//            {
//                ProductId = id,
//                ProductName = productDto.ProductName,
//                Description = productDto.Description,
//                OriginalPrice = productDto.OriginalPrice,
//                DiscountPrice = productDto.DiscountPrice,
//                Price = productDto.Price,
//                IsAvailable = productDto.IsAvailable,
//                SubCategoryId = productDto.SubCategoryId
//            };

//            await _productService.UpdateProductAsync(dto, productDto.ImageFile);

//            return Ok(new { message = "Product updated successfully!" });
//        }



//        //  Delete product
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduct(int id)
//        {
//            await _productService.DeleteProductAsync(id);
//            return Ok(new { message = "Product deleted successfully!" });
//        }
//    }
//}


using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // ✅ Get all products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // ✅ Get product by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // ✅ Get only product image by productId
        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetProductImage(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.Image == null) return NotFound();
            return File(product.Image, "image/jpeg");
        }

        // ✅ Get Subcategories by CategoryId
        [HttpGet("subcategories/{categoryId}")]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCategories = await _categoryService.GetSubCategoriesByCategoryIdAsync(categoryId);
            if (subCategories == null || !subCategories.Any())
                return NotFound(new { message = "No subcategories found for this category" });

            return Ok(subCategories);
        }

        // ✅ Get Products by CategoryId
        [HttpGet("byCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            if (products == null || !products.Any())
                return NotFound(new { message = "No products found for this category" });

            return Ok(products);
        }

        // ✅ Get Products by SubCategoryId
        [HttpGet("bySubCategory/{subCategoryId}")]
        public async Task<IActionResult> GetProductsBySubCategoryId(int subCategoryId)
        {
            var products = await _productService.GetProductsBySubCategoryIdAsync(subCategoryId);
            if (products == null || !products.Any())
                return NotFound(new { message = "No products found for this subcategory" });

            return Ok(products);
        }

        // ✅ Add product (upload image using form-data)
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddProduct([FromForm] ProductCreateDTO productDto)
        {
            var dto = new ProductDTO
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                OriginalPrice = productDto.OriginalPrice,
                DiscountPrice = productDto.DiscountPrice,
                Price = productDto.Price,
                IsAvailable = productDto.IsAvailable,
                SubCategoryId = productDto.SubCategoryId
            };

            await _productService.AddProductAsync(dto, productDto.ImageFile);
            return Ok(new { message = "Product added successfully!" });
        }

        // ✅ Update product
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductUpdateDTO productDto)
        {
            var dto = new ProductDTO
            {
                ProductId = id,
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                OriginalPrice = productDto.OriginalPrice,
                DiscountPrice = productDto.DiscountPrice,
                Price = productDto.Price,
                IsAvailable = productDto.IsAvailable,
                SubCategoryId = productDto.SubCategoryId
            };

            await _productService.UpdateProductAsync(dto, productDto.ImageFile);
            return Ok(new { message = "Product updated successfully!" });
        }

        // ✅ Delete product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Product deleted successfully!" });
        }
    }
}
