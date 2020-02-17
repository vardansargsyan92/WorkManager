using AndroidX.Work;
using Java.Util.Concurrent;
using WorkManagerSample.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationScheduler))]

namespace WorkManagerSample.Droid
{
    public class NotificationScheduler : INotificationScheduler
    {
        public void ScheduleJob(int seconds)
        {
            OneTimeWorkRequest workRequest = OneTimeWorkRequest.Builder.From<NotificationWorker>().SetInitialDelay(seconds, TimeUnit.Seconds).Build();
            WorkManager.Instance.Enqueue(workRequest);
        }
    }
}