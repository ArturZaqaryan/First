using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class PaymentsServiceFactory(IServiceProvider serviceProvider) : IPaymentsServiceFactory
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public IPaymentsService GetService(PaymentMethod paymentMethod)
    {
        return paymentMethod switch
        {
            PaymentMethod.ArCaPay => serviceProvider.GetRequiredService<ArCaPaymentsService>(),
            PaymentMethod.VisaPay => serviceProvider.GetRequiredService<VisaPaymentsService>(),
            _ => throw new ArgumentException("Specified payment method not found!!!"),
        };
    }
}
