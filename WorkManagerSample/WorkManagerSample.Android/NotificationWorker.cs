using System;
using Android.Content;
using Android.Runtime;
using AndroidX.Work;

namespace WorkManagerSample.Droid
{
    public class NotificationWorker : Worker
    {
        public NotificationWorker(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public NotificationWorker(Context context, WorkerParameters workerParams) : base(context, workerParams)
        {
        }

        public override Result DoWork()
        {
            var manager = new LocalNotificationManager();
            manager.Notify("Test Title", "Message");
            return Result.InvokeSuccess();
        }
    }
}