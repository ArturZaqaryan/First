using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.HTTP;

public class ProductsService(ProductsClient productsClient) : IProductsService
{
    private readonly ProductsClient productsClient = productsClient;
    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await productsClient.GetByCategory(category);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await productsClient.GetById(id);
    }

    public async Task<int> AddAsync(Product product)
    {
        return await productsClient.Add(product);
    }
}
