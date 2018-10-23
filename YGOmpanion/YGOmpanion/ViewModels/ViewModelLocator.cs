using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Xamarin.Forms;
using YGOmpanion.Data.Services;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public class ViewModelLocator
    {
        public static IContainer Container;

        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            var platformService = DependencyService.Get<IPlatformService>();

            var navigationService = GetNavigationService();
            
            builder.Register(c => new LocalDataService(platformService.GetDatabaseFilePath())).As<IDataService>().InstancePerLifetimeScope();
            builder.Register(c => new CardImageService()).As<ICardImageService>();
            builder.Register(c => platformService.CreateDialogServiceInstance()).As<GalaSoft.MvvmLight.Views.IDialogService>();
            builder.Register(c => navigationService).As<INavigationService>();
            builder.RegisterType<AddDeckViewModel>().AsSelf();
            builder.RegisterType<DecksViewModel>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<SearchViewModel>().AsSelf();

            Container = builder.Build();

            var serviceLocator = new AutofacServiceLocator(Container);

            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        private static INavigationService GetNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(nameof(Views.AddDeckPage), typeof(Views.AddDeckPage));
            navigationService.Configure(nameof(Views.DecksPage), typeof(Views.DecksPage));
            navigationService.Configure(nameof(Views.MainPage), typeof(Views.MainPage));
            navigationService.Configure(nameof(Views.SearchPage), typeof(Views.SearchPage));

            return navigationService;
        }

        public AddDeckViewModel AddDeck
        {
            get { return ServiceLocator.Current.GetInstance<AddDeckViewModel>(); }
        }

        public DecksViewModel Decks
        {
            get { return ServiceLocator.Current.GetInstance<DecksViewModel>(); }
        }

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public SearchViewModel Search
        {
            get { return ServiceLocator.Current.GetInstance<SearchViewModel>(); }
        }
    }
}
