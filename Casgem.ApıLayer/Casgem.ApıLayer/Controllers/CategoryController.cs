using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApıLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult ListCategory()
        {
            var values = _categoryService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            _categoryService.TInsert(p);
            return Ok("Kategori eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) 
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult PutCategory(Category p)
        {
            _categoryService.TUpdate(p);
            return Ok();
        }
    }
}
