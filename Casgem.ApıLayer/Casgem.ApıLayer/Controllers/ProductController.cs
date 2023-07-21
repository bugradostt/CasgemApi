using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApıLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ListProduct() 
        {
            var values = _productService.TGetList();
            return Ok(values);
        }

        [HttpGet("ListProductWithCategory")]
        public IActionResult ListProductWithCategory()
        {
            var values = _productService.TGetProductWithCategories();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            _productService.TInsert(p);
            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
           var foundId = _productService.TGetById(id);
            _productService.TDelete(foundId);
            return Ok("Ürün Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult EditProduct(Product p)
        {
            _productService.TUpdate(p);
            return Ok("Ürün Güncellendi");
        }
    }
}
