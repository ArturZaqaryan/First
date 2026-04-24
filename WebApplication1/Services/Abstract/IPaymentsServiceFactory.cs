using WebApplication1.Models;

namespace WebApplication1.Services.Abstract;

public interface IPaymentsServiceFactory
{
    IPaymentsService GetService(PaymentMethod paymentMethod);
}
