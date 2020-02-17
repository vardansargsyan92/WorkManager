namespace WorkManagerSample
{
    public interface INotificationScheduler
    {
        void ScheduleJob(int seconds);
    }
}