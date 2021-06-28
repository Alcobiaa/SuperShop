using Microsoft.AspNetCore.Mvc;
using SuperShop.Data;

namespace SuperShop.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productsRepository;

        public ProductsController(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productsRepository.GetAll());
        }

    }
}
