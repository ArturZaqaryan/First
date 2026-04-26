using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class MonitoringService : IMonitoringService
{
    private int requestsCount = 0;
    private TimeSpan requestsTotalDuration = TimeSpan.FromSeconds(0);

    public void IncrementRequestsCount()
    {
        requestsCount++;
    }

    public void AddToTotalDuration(TimeSpan duration)
    {
        requestsTotalDuration += duration;
    }

    public int GetTotalCount() 
    { 
        return requestsCount; 
    }

    public TimeSpan GetTotalDuration()
    {
        return requestsTotalDuration;
    }
}
