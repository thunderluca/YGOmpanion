using System;
using System.IO;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using YGOmpanion.Android.Services;
using YGOmpanion.Services;

[assembly: Dependency(typeof(DroidPlatformService))]
namespace YGOmpanion.Android.Services
{
    public class DroidPlatformService : IPlatformService
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
