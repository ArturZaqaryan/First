using WebApplication1.Models;

namespace WebApplication1.Services.Abstract;

public interface IPaymentsService
{
    void Pay(Payment payment);
    string MethodName {  get; }
}
