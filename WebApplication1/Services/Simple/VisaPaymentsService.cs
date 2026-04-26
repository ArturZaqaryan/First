using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class VisaPaymentsService : IPaymentsService
{
    public string MethodName => "Payment System: VisaPayment";

    public void Pay(Payment payment)
    {
        Thread.Sleep(100);
    }
}
