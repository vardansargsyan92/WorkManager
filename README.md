# WorkManager

WorkManager Give a warm welcome to WorkManager. WorkManager is a library that makes it easy to schedule deferrable, asynchronous tasks even if the app exits or the device restarts. It was designed to be backwards compatible to API 14 and does so by wrapping JobScheduler, AlarmManager, and BroadcastReceivers all in one.  Using JobScheduler your app will be running on a device that is API 23+. Anything below, you’ll be using a combination of AlarmManager + BroadcastReceivers.
