using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.HTTP;

public class ProductsService(ProductsClient productsClient) : IProductsService
{
    private readonly ProductsClient productsClient = productsClient;
    public IEnumerable<Product> GetByCategory(string category)
    {
        return productsClient.GetByCategory(category).Result;
    }

    public Product GetById(int id)
    {
        return productsClient.GetById(id).Result;
    }

    public int Add(Product product)
    {
        return 5;//productsClient.Add(product).Result;
    }
}
