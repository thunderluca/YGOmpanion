using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using YGOmpanion.Data.Services;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public class DecksViewModel : BaseViewModel
    {
        private readonly IDataService DataService;

        public DecksViewModel(IDataService dataService, GalaSoft.MvvmLight.Views.IDialogService dialogService, INavigationService navigationService) : base(dialogService, navigationService)
        {
            this.Title = "Saved decks";
            this.DataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public ObservableCollection<Deck> Decks { get; set; }

        private string query = string.Empty;
        public string Query
        {
            get { return query; }
            set { Set(nameof(Query), ref query, value); }
        }

        private bool showEmptyDecksListMessage = false;
        public bool ShowEmptyDecksListMessage
        {
            get { return showEmptyDecksListMessage; }
            set { Set(nameof(ShowEmptyDecksListMessage), ref showEmptyDecksListMessage, value); }
        }

        private RelayCommand addDeckCommand;
        public RelayCommand AddDeckCommand
        {
            get
            {
                if (addDeckCommand == null)
                {
                    addDeckCommand = new RelayCommand(AddDeck);
                }

                return addDeckCommand;
            }
        }

        public async void Refresh()
        {
            if (this.IsBusy) return;

            this.IsBusy = true;

            this.Decks.Clear();

            var savedDecks = await this.DataService.GetDecksAsync(this.Query);
            if (savedDecks?.Count == 0)
            {
                this.ShowEmptyDecksListMessage = true;
                this.IsBusy = false;
                return;
            }

            var decks = savedDecks.Select(ToDeck).ToArray();
            foreach (var deck in decks)
            {
                this.Decks.Add(deck);
            }

            this.IsBusy = false;
        }

        private Deck ToDeck(Data.Models.Deck deck)
        {
            return new Deck
            {
                Id = deck.Id,
                Name = deck.Name,
                CreatedOn = deck.CreatedOn.ToShortDateString(),
                CardsCount = deck.CardsCount + " card/s"
            };
        }

        private void AddDeck()
        {
            this.NavigationService.NavigateAsync(nameof(Views.AddDeckPage));
        }

        public class Deck
        {
            public int Id { get; set; }

            public string Name { get; set; }
            
            public string CardsCount { get; set; }

            public string CreatedOn { get; set; }
        }
    }
}
