using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class ProductsService : IProductsService
{
    private readonly List<Product> products =
            [
                new Product
                {
                    Id = 9,
                    Title = "WD 2TB Elements Portable External Hard Drive - USB 3.0 ",
                    Price = 64,
                    Description = "USB 3.0 and USB 2.0 Compatibility Fast data transfers Improve PC Performance High Capacity...",
                    Category = "electronics",
                    Image = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_t.png",
                    Rating = new Rating
                    {
                        Rate = 3.3,
                        Count = 203
                    }
                },
                new Product
                {
                    Id = 10,
                    Title = "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s",
                    Price = 109,
                    Description = "Easy upgrade for faster boot up, shutdown...",
                    Category = "electronics",
                    Image = "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_t.png",
                    Rating = new Rating
                    {
                        Rate = 2.9,
                        Count = 470
                    }
                },
                new Product
                {
                    Id = 11,
                    Title = "Silicon Power 256GB SSD 3D NAND A55...",
                    Price = 109,
                    Description = "3D NAND flash are applied to deliver high transfer speeds...",
                    Category = "electronics",
                    Image = "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_t.png",
                    Rating = new Rating
                    {
                        Rate = 4.8,
                        Count = 319
                    }
                },
                new Product
                {
                    Id = 12,
                    Title = "WD 4TB Gaming Drive Works with Playstation 4",
                    Price = 114,
                    Description = "Expand your PS4 gaming experience...",
                    Category = "electronics",
                    Image = "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_t.png",
                    Rating = new Rating
                    {
                        Rate = 4.8,
                        Count = 400
                    }
                },
                new Product
                {
                    Id = 13,
                    Title = "Acer SB220Q bi 21.5 inches Full HD",
                    Price = 599,
                    Description = "21.5 inches Full HD IPS display...",
                    Category = "Category 2",
                    Image = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_t.png",
                    Rating = new Rating
                    {
                        Rate = 2.9,
                        Count = 250
                    }
                },
                new Product
                {
                    Id = 14,
                    Title = "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor",
                    Price = 999.99m,
                    Description = "49 inch super ultrawide curved gaming monitor...",
                    Category = "Category 3",
                    Image = "https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_t.png",
                    Rating = new Rating
                    {
                        Rate = 2.2,
                        Count = 140
                    }
                }
            ];

    public IEnumerable<Product> GetByCategory(string category)
    {
        return products.Where(p => p.Category == category);
    }

    public Product GetById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public int Add(Product product)
    {
        product.Id = Random.Shared.Next(1000);
        products.Add(product);

        return product.Id;
    }
}
