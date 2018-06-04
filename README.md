## MediaManager - Cross platform media plugin for Xamarin

This is my own rebase and update for [MediaManager](https://github.com/martijn00/XamarinMediaManager/). Go check it out, it's really good.

I have separated the platform specific codebases into separate platform class libraries instead of keeping them in the .NET Standard library, as compiling specific classes could be set for each target platform, but the compiler still checked each reference, and failed with the Xamarin.Android packages that were only targetting MonoAndroid 8.1 (not .NET Standard).

Because I'm only interested in Android and iOS cross platform development, I have only included those platforms as class libraries. The other platform specific code can be rebased into their class libraries as needed.

In terms of use, this means we can't rely on the compiler tagged code on the CrossMediaManager class to instantiate a new MediaManagerImplemention for its Current property in its getter. Instead add the following line to `MainActivity.cs` and `AppDelegate.cs` for Android and iOS respectively:
`CrossMediaManager.Current = new MediaManagerImplementation();`

I have also updated the ExoPlayer implementation to use the latest 2.8.3 package, and updated the Android code to target API 27 (Oreo 8.1).

I have included an example demo app which includes the setting of `CrossMediaManager.Current` and includes a custom NotificationManager for Android, and setting it to use ExoPlayer.

