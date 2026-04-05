using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class ArCaPaymentsService : IPaymentsService
{
    public void Pay(Payment payment)
    {
        Thread.Sleep(100);
    }

    public override string ToString()
    {
        return "Payment System: ArCaPayment";
    }
}
