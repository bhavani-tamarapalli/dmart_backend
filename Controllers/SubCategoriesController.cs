using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Dmart_web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = "BasicAuthentication")]


    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoriesController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            var subCategories = await _service.GetAllAsync();
            return Ok(subCategories);
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var subCategories = await _service.GetByCategoryAsync(categoryId);
            return Ok(subCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SubCategoryDTO dto)
        {
            var message = await _service.AddAsync(dto);
            return Ok(new { message });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubCategoryDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result)
                return NotFound(new { message = "Subcategory not found." });

            return Ok(new { message = "Subcategory updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Subcategory not found." });

            return Ok(new { message = "Subcategory deleted successfully." });
        }

    }
}
