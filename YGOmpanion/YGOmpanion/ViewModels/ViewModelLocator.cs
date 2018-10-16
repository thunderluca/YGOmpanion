using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using YGOmpanion.Data;

namespace YGOmpanion.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new Database());
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
