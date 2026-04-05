namespace WebApplication1.Services.Abstract
{
    public interface IMonitoringService
    {
        void AddToTotalDuration(TimeSpan duration);
        void IncrementRequestsCount();
        int GetTotalCount();
        TimeSpan GetTotalDuration();
    }
}