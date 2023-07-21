using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApıLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult ListCustomer() 
        {
            var values = _customerService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            _customerService.TInsert(p);
            return Ok("Eklendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id) 
        {
            var foundId = _customerService.TGetById(id);
            _customerService.TDelete(foundId);
            return Ok("Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer p)
        {
            _customerService.TUpdate(p);
            return Ok("Güncellendi");
        }
    }
}
