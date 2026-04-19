using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class UserRegister
{
    [Required]
    [MinLength(3, ErrorMessage = $"{nameof(this.Username)} must be at least 3 characters")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    public decimal Price { get; set; }

    [Range(0, 50)]
    public int Amount { get; set; }
}
