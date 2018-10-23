using System.IO;
using GalaSoft.MvvmLight.Views;
using Windows.Storage;
using Xamarin.Forms;
using YGOmpanion.Services;
using YGOmpanion.UWP.Services;

[assembly: Dependency(typeof(UWPPlatformService))]
namespace YGOmpanion.UWP.Services
{
    public class UWPPlatformService : IPlatformService
    {
        public IDialogService CreateDialogServiceInstance()
        {
            return new DialogService();
        }

        public string GetDatabaseFilePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, "cards.db");
        }
    }
}
