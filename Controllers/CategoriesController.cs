//Basic AUthentication

//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;


//namespace Dmart_web.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]



//    //[Authorize(AuthenticationSchemes = "BasicAuthentication")]

//    public class CategoriesController : ControllerBase
//    {
//        private readonly ICategoryService _service;

//        public CategoriesController(ICategoryService service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var categories = await _service.GetAllAsync();
//            return Ok(categories);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult>GetById(int id)
//        {
//            var category=await _service.GetByIdAsync(id);
//            if(category==null)
//                return NotFound();

//            return Ok(category);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add(CategoryDTO dto)
//        {
//            var message = await _service.AddAsync(dto);
//            return Ok(new { message });
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var result = await _service.UpdateAsync(id, dto);
//            if (!result)
//                return NotFound(new { message = "Category not found or update failed" });

//            return Ok(new { message = "Category updated successfully" });
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await _service.DeleteAsync(id);
//            if (!result)
//                return NotFound(new { message = "Category not found or delete failed" });

//            return Ok(new { message = "Category deleted successfully" });
//        }
//    }
//}


using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace Dmart_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            if (category == null)
                return NotFound(new { message = "Category not found" });

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO dto)
        {
            var message = await _service.AddAsync(dto);
            return Ok(new { message });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            if (!result)
                return NotFound(new { message = "Category not found or update failed" });

            return Ok(new { message = "Category updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Category not found or delete failed" });

            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
