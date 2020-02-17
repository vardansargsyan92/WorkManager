using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Java.Lang;
using AndroidApp = Android.App.Application;

namespace WorkManagerSample.Droid
{
    public class LocalNotificationManager
    {
        public void Notify(string title, string message)
        {
            ScheduleNotification(title, message);
        }

        private const string ChannelId = "default";
        private const string ChannelName = "Default";
        private const string ChannelDescription = "The default channel for notifications.";
        private const int PendingIntentId = 0;

        private const string TitleKey = "title";
        private const string MessageKey = "message";

        private bool _channelInitialized;
        private int _messageId = -1;
        private NotificationManager _manager;

        private void ScheduleNotification(string title, string message)
        {
            if(!_channelInitialized)
            {
                CreateNotificationChannel();
            }

            _messageId++;

            var intent = new Intent(AndroidApp.Context, typeof(MainActivity));
            intent.PutExtra(TitleKey, title);
            intent.PutExtra(MessageKey, message);

            PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, PendingIntentId, intent, PendingIntentFlags.OneShot);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, ChannelId)
                                                 .SetContentIntent(pendingIntent)
                                                 .SetContentTitle(title)
                                                 .SetContentText(message)
                                                 .SetSmallIcon(Resource.Drawable.xamagonBlue)
                                                 .SetLargeIcon(BitmapFactory.DecodeResource(AndroidApp.Context.Resources, Resource.Drawable.xamagonBlue))
                                                 .SetDefaults((int) NotificationDefaults.Sound | (int) NotificationDefaults.Vibrate);

            Notification notification = builder.Build();
            _manager.Notify(_messageId, notification);
        }

        private void CreateNotificationChannel()
        {
            _manager = (NotificationManager) AndroidApp.Context.GetSystemService(Context.NotificationService);

            if(Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new String(ChannelName);
                var channel = new NotificationChannel(ChannelId, channelNameJava, NotificationImportance.Default)
                              {
                                  Description = ChannelDescription
                              };
                _manager.CreateNotificationChannel(channel);
            }

            _channelInitialized = true;
        }
    }
}