using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models.Category;

namespace VakifBankKrediKullandirimAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public ProductCategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetParents")]
        public async Task<ActionResult<List<ProductParentCategory>>> GetParentCategories()
        {
            return Ok(await _categoryRepository.GetAllParentCategoriesAsync());
        }

        [HttpGet]
        [Route("GetChildren")]
        public async Task<ActionResult<List<ProductCategory>>> GetChildrenCategories(string code)
        {
            var parent = await _categoryRepository.GetParentCategoryByCodeAsync(code);
            return Ok(await _categoryRepository.GetAllChildrenFromParentCategoryByIdAsync(parent.Id));
        }
    }
}
