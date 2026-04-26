using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class ArCaPaymentsService : IPaymentsService
{
    string IPaymentsService.MethodName => "Payment System: ArCaPayment";

    public void Pay(Payment payment)
    {
        Thread.Sleep(100);
    }
}
