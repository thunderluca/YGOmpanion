using Android.App;
using Android.Content.PM;
using Android.OS;
using System.IO;
using YGOmpanion.Helpers;

namespace YGOmpanion.Droid
{
    [Activity(Label = nameof(YGOmpanion), Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var databaseFilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "cards.db");

            StorageHelper.CopyCardsDb(databaseFilePath);

            Xamarin.Forms.Forms.Init(this, bundle);
            global::Android.Glide.Forms.Init();
            LoadApplication(new App());
        }
    }
}