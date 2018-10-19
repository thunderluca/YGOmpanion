using Foundation;
using System;
using System.IO;
using UIKit;
using YGOmpanion.Helpers;

namespace YGOmpanion.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var databaseFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "cards.db");

            StorageHelper.CopyCardsDb(databaseFilePath);

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
