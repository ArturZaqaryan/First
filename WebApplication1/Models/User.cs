using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = $"{nameof(Username)} must be at least 3 characters")]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Email)} is not valid")]
    public string Email { get; set; }
}
