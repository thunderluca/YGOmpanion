using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using YGOmpanion.Services;
using YGOmpanion.UWP.Services;

[assembly: Dependency(typeof(UWPPlatformService))]
namespace YGOmpanion.UWP.Services
{
    public class UWPPlatformService : IPlatformService
    {
        public string GetDatabaseFilePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, "cards.db");
        }
    }
}
