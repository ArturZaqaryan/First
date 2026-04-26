using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(IProductsService productsService, CounterService counterService) : ControllerBase
    {
        private readonly IProductsService productsService = productsService;
        private readonly CounterService counterService = counterService;

        [HttpGet()]
        public IEnumerable<Product> Get(string category)
        {
            return this.productsService.GetByCategory(category);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var result = this.productsService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            var result = new { id = this.productsService.Add(product) };

            return CreatedAtAction(nameof(Get), result, result);
        }
    }
}
