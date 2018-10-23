using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using YGOmpanion.Data.Models;
using YGOmpanion.Data.Services;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IDataService DataService;
        private readonly ICardImageService CardImageService;

        public SearchViewModel(
            IDataService dataService, 
            ICardImageService cardImageService,
            GalaSoft.MvvmLight.Views.IDialogService dialogService,
            INavigationService navigationService) : base(dialogService, navigationService)
        {
            this.Title = "Search cards";
            DataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            CardImageService = cardImageService ?? throw new ArgumentNullException(nameof(cardImageService));

            FoundCards = new ObservableCollection<Card>();
        }

        private string query = string.Empty;
        public string Query
        {
            get { return query; }
            set { Set(nameof(Query), ref query, value); }
        }

        public ObservableCollection<Card> FoundCards { get; set; }

        private bool showEmptyCardsListMessage = false;
        public bool ShowEmptyCardsListMessage
        {
            get { return showEmptyCardsListMessage; }
            set { Set(nameof(ShowEmptyCardsListMessage), ref showEmptyCardsListMessage, value); }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(Search);
                }

                return searchCommand;
            }
        }

        private async void Search()
        {
            if (this.IsBusy) return;

            this.IsBusy = true;

            this.FoundCards.Clear();

            if (string.IsNullOrWhiteSpace(this.Query))
            {
                this.ShowEmptyCardsListMessage = true;
                this.IsBusy = false;
                return;
            }

            var foundCards = await DataService.SearchCardsAsync(this.Query);
            if (foundCards?.Count == 0)
            {
                this.ShowEmptyCardsListMessage = true;
                this.IsBusy = false;
                return;
            }

            if (foundCards?.Count > 50)
            {
                this.IsBusy = false;
                await this.DialogService.ShowMessage("Too many results", "Warning");
                return;
            }

            this.ShowEmptyCardsListMessage = false;

            var cards = foundCards.Select(this.ToCard).ToArray();
            foreach (var card in cards)
            {
                this.FoundCards.Add(card);
            }

            this.IsBusy = false;
            
            //foreach (var card in this.FoundCards)
            //{
            //    if (!string.IsNullOrWhiteSpace(card.ImageUrl)) continue;

            //    var imageUrl = await this.CardImageService.GetImageUrlAsync(card.Name);

            //    await this.DataService.UpdateCardImageUrlAsync(card.Id, imageUrl);
            //}
        }

        private Card ToCard(Data.Models.Card card)
        {
            var attack = $"ATK {(card.IsMonster() ? card.Attack < 0 ? "?" : card.Attack.ToString() : string.Empty)}";
            var defense = $"DEF {(card.IsMonster() ? card.Defense < 0 ? "?" : card.Defense.ToString() : string.Empty)}";

            return new Card
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                Attribute = card.IsMonster() ? card.Attribute : card.Attribute.Split('/')[card.IsMagic() ? 0 : 1],
                CardTypes = card.IsMonster() ? card.Race + "/" + card.Type : card.Type,
                Attack = attack,
                Defense = defense,
                Type = card.GetCardType(),
                IsMonster = card.IsMonster(),
                ImageUrl = card.ImageUrl
            };
        }
        
        public class Card : GalaSoft.MvvmLight.ViewModelBase
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public string CardTypes { get; set; }

            public string Attribute { get; set; }
            
            public string Attack { get; set; }

            public string Defense { get; set; }

            public CardType Type { get; set; }

            public bool IsMonster { get; set; }

            private string imageUrl;
            public string ImageUrl
            {
                get { return imageUrl; }
                set { Set(nameof(ImageUrl), ref imageUrl, value); }
            }
        }
    }
}
