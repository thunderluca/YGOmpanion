using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YGOmpanion.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> History;
        private readonly Stack<NavigationPage> NavigationPageStack;

        public NavigationService()
        {
            this.History = new Dictionary<string, Type>();
            this.NavigationPageStack = new Stack<NavigationPage>();
        }

        public string CurrentPageKey
        {
            get
            {
                lock (History)
                {
                    if (CurrentNavigationPage?.CurrentPage == null) return null;

                    var pageType = CurrentNavigationPage.CurrentPage.GetType();

                    return History.ContainsValue(pageType) ? History.First(p => p.Value == pageType).Key : null;
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (History)
            {
                if (History.ContainsKey(pageKey))
                {
                    History[pageKey] = pageType;
                }
                else
                {
                    History.Add(pageKey, pageType);
                }
            }
        }

        public async Task GoBack()
        {
            var navigationStack = CurrentNavigationPage.Navigation;
            if (navigationStack.NavigationStack.Count > 1)
            {
                await CurrentNavigationPage.PopAsync();
                return;
            }

            if (NavigationPageStack.Count > 1)
            {
                NavigationPageStack.Pop();
                await CurrentNavigationPage.Navigation.PopModalAsync();
                return;
            }

            await CurrentNavigationPage.PopAsync();
        }

        public async Task NavigateModalAsync(string pageKey, bool animated = true)
        {
            await NavigateModalAsync(pageKey, null, animated);
        }

        public async Task NavigateModalAsync(string pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);

            NavigationPage.SetHasNavigationBar(page, false);

            var modalNavigationPage = new NavigationPage(page);

            await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, animated);

            NavigationPageStack.Push(modalNavigationPage);
        }

        public async Task NavigateAsync(string pageKey, bool animated = true)
        {
            await NavigateAsync(pageKey, null, animated);
        }

        public async Task NavigateAsync(string pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);

            await CurrentNavigationPage.Navigation.PushAsync(page, animated);
        }

        public Page SetRootPage(string rootPageKey)
        {
            var rootPage = GetPage(rootPageKey);

            NavigationPageStack.Clear();

            var mainPage = new NavigationPage(rootPage);

            NavigationPageStack.Push(mainPage);

            return mainPage;
        }

        private NavigationPage CurrentNavigationPage => NavigationPageStack.Peek();

        private Page GetPage(string pageKey) => GetPage(pageKey, null);

        private Page GetPage(string pageKey, object parameter)
        {
            lock (History)
            {
                if (!History.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("Page not found or not configured with key {0}.", pageKey), nameof(pageKey));
                }

                var type = History[pageKey];
                ConstructorInfo constructor;
                object[] parameters;

                if (parameter == null)
                {
                    constructor = type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => !c.GetParameters().Any());

                    parameters = new object[0];
                }
                else
                {
                    constructor = type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c =>
                    {
                        var p = c.GetParameters();
                        return p.Count() == 1 && p[0].ParameterType == parameter.GetType();
                    });

                    parameters = new[] { parameter };
                }

                return constructor.Invoke(parameters) as Page;
            }
        }
    }
}
