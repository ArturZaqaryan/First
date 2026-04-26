using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentsServiceFactory paymentsServiceFactory, CounterService counterService) : ControllerBase
    {
        private readonly IPaymentsServiceFactory paymentsServiceFactory = paymentsServiceFactory;
        private readonly CounterService counterService = counterService;


        [HttpPost]
        public string Post([FromBody] Payment payment)
        {
            var service = this.paymentsServiceFactory.GetService(payment.PaymentMethod);
            service.Pay(payment);

            return service.MethodName;
        }
    }
}
