using GalaSoft.MvvmLight.Command;
using System;
using YGOmpanion.Data.Services;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public class AddDeckViewModel : BaseViewModel
    {
        private readonly IDataService DataService;

        public AddDeckViewModel(IDataService dataService, GalaSoft.MvvmLight.Views.IDialogService dialogService, INavigationService navigationService) : base(dialogService, navigationService)
        {
            this.Title = "Add new deck";
            this.DataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { Set(nameof(Name), ref name, value); }
        }

        private bool validName = true;
        public bool ValidName
        {
            get { return validName; }
            set { Set(nameof(ValidName), ref validName, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { Set(nameof(Description), ref description, value); }
        }

        private bool validDescription = true;
        public bool ValidDescription
        {
            get { return validDescription; }
            set { Set(nameof(ValidName), ref validDescription, value); }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(Save);
                }

                return saveCommand;
            }
        }

        private async void Save()
        {
            if (this.IsBusy) return;

            this.ValidName = !string.IsNullOrWhiteSpace(this.Name);

            this.ValidDescription = !string.IsNullOrWhiteSpace(this.Description);

            if (!this.ValidName || !this.ValidDescription) return;

            this.IsBusy = true;

            var deck = new Data.Models.Deck
            {
                Name = this.Name,
                Description = this.Description,
                CardsCount = 0,
                CreatedOn = DateTime.UtcNow
            };

            try
            {
                var deckId = await this.DataService.AddNewDeckAsync(deck);

                
            }
            catch (Exception)
            {

            }

            this.IsBusy = false;
        }
    }
}
