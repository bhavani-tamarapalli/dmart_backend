using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService _productService;
        public SearchController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> SearchProducts(
               [FromQuery] string query,
               [FromQuery] int page = 1,
               [FromQuery] int pageSize = 20)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return BadRequest(new { message = "Search query cannot be empty" });
                }

                var searchResults = await _productService.SearchProductsAsync(query, page, pageSize);

                if (searchResults == null || !searchResults.Products.Any())
                {
                    // Return a 200 OK with an empty list and a message, as this is a valid response.
                    return Ok(new SearchResultDTO
                    {
                        Products = new List<ProductSearchDTO>(),
                        TotalCount = 0,
                        CurrentPage = page,
                        PageSize = pageSize,
                        TotalPages = 0,
                        SearchQuery = query,
                        Message = "No products found"
                    });
                }

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while searching products",
                    error = ex.Message
                });
            }
        }

        [HttpGet("suggestions")]
        public async Task<IActionResult> GetSearchSuggestions([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
                {
                    return Ok(new SearchSuggestionDTO { Suggestions = new List<string>(), Query = query });
                }

                var suggestions = await _productService.GetSearchSuggestionsAsync(query);

                return Ok(new SearchSuggestionDTO
                {
                    Suggestions = suggestions,
                    Query = query
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while getting suggestions",
                    error = ex.Message
                });
            }
        }
    }
}