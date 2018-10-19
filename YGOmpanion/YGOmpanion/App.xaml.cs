using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YGOmpanion.Helpers;
using YGOmpanion.Services;
using YGOmpanion.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace YGOmpanion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var platformService = DependencyService.Get<IPlatformService>();

            StorageHelper.CopyCardsDb(platformService.GetDatabaseFilePath());

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
