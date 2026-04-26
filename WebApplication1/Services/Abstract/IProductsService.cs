using WebApplication1.Models;

namespace WebApplication1.Services.Abstract;

public interface IProductsService
{
    int Add(Product product);
    Product GetById(int id);
    IEnumerable<Product> GetByCategory(string category);

}
