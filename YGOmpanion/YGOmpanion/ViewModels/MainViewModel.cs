using GalaSoft.MvvmLight.Command;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(GalaSoft.MvvmLight.Views.IDialogService dialogService, INavigationService navigationService) : base(dialogService, navigationService)
        {
            this.Title = "Home";
        }

        private RelayCommand goToDecksCommand;
        public RelayCommand GoToDecksCommand
        {
            get
            {
                if (goToDecksCommand == null)
                {
                    goToDecksCommand = new RelayCommand(GoToDecks);
                }

                return goToDecksCommand;
            }
        }

        private RelayCommand goToSearchCommand;
        public RelayCommand GoToSearchCommand
        {
            get
            {
                if (goToSearchCommand == null)
                {
                    goToSearchCommand = new RelayCommand(GoToSearch);
                }

                return goToSearchCommand;
            }
        }

        private void GoToDecks()
        {
            this.NavigationService.NavigateAsync(nameof(Views.DecksPage));
        }

        private void GoToSearch()
        {
            this.NavigationService.NavigateAsync(nameof(Views.SearchPage));
        }
    }
}
