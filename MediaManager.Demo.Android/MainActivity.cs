using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Plugin.MediaManager;
using Plugin.MediaManager.ExoPlayer;

namespace MediaManager.Demo.Droid
{
    [Activity(Label = "MediaManager.Demo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // init packages
            Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(enableFastRenderer: true);
            CrossMediaManager.Current = new MediaManagerImplementation();

            // use custom Android notifications
            CrossMediaManager.Current.MediaNotificationManager = new PVLMediaNotificationManager(Application.Context, typeof(ExoPlayerAudioService));
            //CrossMediaManager.Current.MediaNotificationManager = new PVLMediaNotificationManager(Application.Context, typeof(MediaPlayerService));

            // use exoPlayer
            MediaManagerImplementation current = CrossMediaManager.Current as MediaManagerImplementation;
            var exoPlayer = new ExoPlayerAudioImplementation(current.MediaSessionManager);
            CrossMediaManager.Current.AudioPlayer = exoPlayer;

            LoadApplication(new App());
        }
    }
}

