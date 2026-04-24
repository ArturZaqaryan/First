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
        public async Task<IEnumerable<Product>> GetAsync(string category)
        {
            return await productsService.GetByCategoryAsync(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            var result = this.productsService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return await result;
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            var result = new { id = this.productsService.AddAsync(product) };

            return CreatedAtAction(nameof(GetAsync), result, result);
        }
    }
}
