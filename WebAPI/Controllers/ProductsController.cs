using Business.Abstract;
using Business.Concrete;
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

        [HttpGet]
        public List<Product> Get()
        {
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
