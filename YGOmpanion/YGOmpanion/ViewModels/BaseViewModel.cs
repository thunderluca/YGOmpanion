using GalaSoft.MvvmLight.Command;
using System;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public abstract class BaseViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public readonly GalaSoft.MvvmLight.Views.IDialogService DialogService;
        public readonly INavigationService NavigationService;

        public BaseViewModel(GalaSoft.MvvmLight.Views.IDialogService dialogService, INavigationService navigationService)
        {
            this.DialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.NavigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { Set(nameof(IsBusy), ref isBusy, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { Set(nameof(Title), ref title, value); }
        }

        private RelayCommand goBackCommand;
        public RelayCommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new RelayCommand(GoBack);
                }

                return goBackCommand;
            }
        }

        public void GoBack()
        {
            this.NavigationService.GoBack();
        }
    }
}
