using Microsoft.AspNetCore.Http;
using WebApplication1.Models;

namespace WebApplication1.Clients;

public class ProductsClient(HttpClient httpClient) : HttpClient
{
    private readonly HttpClient httpClient = httpClient;
    public async Task<IEnumerable<Product>> GetByCategory(string category)
    {
        return await this.httpClient.GetFromJsonAsync<IEnumerable<Product>>($"category/{category}");
    }

    public async Task<Product> GetById(int id)
    {
        return await this.httpClient.GetFromJsonAsync<Product>(id.ToString());
    }

    //public async Task<int> Add(Product product)
    //{
    //    //return await this.httpClient.PostAsJsonAsync<Product>(string.Empty, product); Requests doesnt work, so i cant handle this response.
    //}
}
