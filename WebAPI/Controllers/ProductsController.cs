using Business.Abstract;
using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // It's for defining this class as a controller
    public class ProductsController : ControllerBase
    {
        // Loosely coupled
        IProductService _productService;

        // IoC Container -> Inversion of Control -> İhtiyaç duyulan tüm ProductManager - EfProcudtManager gibi objeleri içinde tutan yapı
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() // IActionResult -> Default result for API Request
        {
            var result = _productService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id) // IActionResult -> Default result for API Request
        {
            var result = _productService.GetAllByProductId(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        
    }
}
