using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class UserRegister : User
{
    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    public decimal Price { get; set; }

    [Range(0, 50)]
    public int Amount { get; set; }
}
