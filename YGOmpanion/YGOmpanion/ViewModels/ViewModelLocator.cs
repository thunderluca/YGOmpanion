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
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            var databasePath = DependencyService.Get<IPlatformService>().GetDatabaseFilePath();

            builder.Register(c => new LocalDataService(databasePath)).As<IDataService>().InstancePerLifetimeScope();
            builder.RegisterType<SearchViewModel>().AsSelf();

            var container = builder.Build();

            var serviceLocator = new AutofacServiceLocator(container);

            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public SearchViewModel Search
        {
            get { return ServiceLocator.Current.GetInstance<SearchViewModel>(); }
        }
    }
}
