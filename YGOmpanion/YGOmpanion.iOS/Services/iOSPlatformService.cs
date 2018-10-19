using System;
using System.IO;
using Xamarin.Forms;
using YGOmpanion.iOS.Services;
using YGOmpanion.Services;

[assembly: Dependency(typeof(iOSPlatformService))]
namespace YGOmpanion.iOS.Services
{
    public class iOSPlatformService : IPlatformService
    {
        public string GetDatabaseFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "cards.db");
        }
    }
}
