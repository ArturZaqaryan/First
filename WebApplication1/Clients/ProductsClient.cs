using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Clients;

public class ProductsClient(HttpClient httpClient)
{
    private readonly HttpClient httpClient = httpClient;
    public async Task<IEnumerable<Product>> GetByCategory(string category)
    {
        return await this.httpClient.GetFromJsonAsync<IEnumerable<Product>>($"products/category/{category}");
    }

    public async Task<Product> GetById(int id)
    {
        return await this.httpClient.GetFromJsonAsync<Product>($"products/{id}");
    }

    public async Task<int> Add(Product product)
    {
        var response = await this.httpClient.PostAsJsonAsync("products/", product);

        response.EnsureSuccessStatusCode();
        string respContent = await response.Content.ReadAsStringAsync();

        Product respProduct = JsonSerializer.Deserialize<Product>(respContent, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        });

        return respProduct == null ? throw new Exception("Internal Server error.") : respProduct.Id;
    }
}
