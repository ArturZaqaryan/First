using WebApplication1.Models;

namespace WebApplication1.Services.Abstract;

public interface IProductsService
{
    Task<int> AddAsync(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);

}
