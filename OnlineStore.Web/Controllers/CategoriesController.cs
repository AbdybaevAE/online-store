using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.UseCases.Interfaces;
using OnlineStore.UseCases.Interfaces.Data;
using OnlineStore.Web.AutoMapperProfiles;
using OnlineStore.Web.Dto;

namespace OnlineStore.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(
        ICategoryService categoryService,
        IMapper mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var foundCategories = (await categoryService.GetAllCategories(CancellationToken.None))
                .Select(mapper.Map<CategoryResult, CategoryDTO>);
            return Ok(foundCategories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryArguments arguments)
        {
            var categoryResult = await categoryService.CreateCategory(arguments, CancellationToken.None);
            return Created($"/api/categories/{categoryResult.CategoryID.Value}", mapper.Map<CategoryResult, CategoryDTO>(categoryResult));
        }
        [HttpGet("{categoryID}")]
        public async Task<IActionResult> GetCategoryByID(Guid categoryID)
        {
            var foundCategory = await categoryService.GetCategoryByID(new CategoryID(categoryID), CancellationToken.None);
            return Ok(mapper.Map<CategoryResult, CategoryDTO>(foundCategory));
        }
        [HttpDelete("{categoryID}")]
        public async Task<IActionResult> DeleteCategoryByID(Guid categoryID)
        {
            await categoryService.DeleteCategory(new CategoryID(categoryID), CancellationToken.None);
            return Ok();
        }
    }
}
