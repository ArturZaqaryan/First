namespace WebApplication1.Models;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount {  get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}

public enum PaymentMethod
{
    ArCaPay,
    VisaPay
}
