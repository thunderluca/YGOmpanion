using System;
using System.IO;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using YGOmpanion.iOS.Services;
using YGOmpanion.Services;

[assembly: Dependency(typeof(IOSPlatformService))]
namespace YGOmpanion.iOS.Services
{
    public class IOSPlatformService : IPlatformService
    {
        public IDialogService CreateDialogServiceInstance()
        {
            return new DialogService();
        }

        public string GetDatabaseFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "cards.db");
        }
    }
}
