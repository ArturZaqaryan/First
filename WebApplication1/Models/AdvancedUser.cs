using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class AdvancedUser : User
{
    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    public decimal Price { get; set; }

    [Range(1, 49)]
    public int Amount { get; set; }
}
