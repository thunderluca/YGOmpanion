using System;
using System.IO;
using Xamarin.Forms;
using YGOmpanion.Android.Services;
using YGOmpanion.Services;

[assembly: Dependency(typeof(DroidPlatformService))]
namespace YGOmpanion.Android.Services
{
    public class DroidPlatformService : IPlatformService
    {
        public string GetDatabaseFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "cards.db");
        }
    }
}
