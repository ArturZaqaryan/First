using System.Diagnostics;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class CounterService : IDisposable
{
    private readonly IMonitoringService monitoringService;
    private readonly Stopwatch stopwatch;

    public CounterService(IMonitoringService monitoringService)
    {
        this.monitoringService = monitoringService;

        this.stopwatch = Stopwatch.StartNew();
        this.stopwatch.Start();

        this.monitoringService.IncrementRequestsCount();
    }

    public void Dispose()
    {
        this.stopwatch.Stop();
        this.monitoringService.AddToTotalDuration(this.stopwatch.Elapsed);
    }
}
