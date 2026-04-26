using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestMetricsController(IMonitoringService monitoringService, CounterService counterService) : ControllerBase
    {
        private readonly IMonitoringService monitoringService = monitoringService;
        private readonly CounterService counterService = counterService;

        [HttpGet]
        public Metric Get()
        {
            var metric = new Metric() 
            {
                RequestsCount = this.monitoringService.GetTotalCount(),
                TotalDuration = this.monitoringService.GetTotalDuration()
            };

            return metric;
        }
    }
}
