using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentsService paymentsService, CounterService counterService) : ControllerBase
    {
        private readonly IPaymentsService paymentsService = paymentsService;
        private readonly CounterService counterService = counterService;


        [HttpPost]
        public string Post([FromBody] Payment payment)
        {
            this.paymentsService.Pay(payment);

            return this.paymentsService.ToString();
        }
    }
}
