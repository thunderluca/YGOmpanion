using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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

        public SearchViewModel(IDataService dataService, ICardImageService cardImageService)
        {
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

            var foundCards = await DataService.SearchAsync(this.Query);
            if (foundCards?.Count == 0)
            {
                this.ShowEmptyCardsListMessage = true;
                this.IsBusy = false;
                return;
            }

            this.ShowEmptyCardsListMessage = false;

            var cards = foundCards.Select(this.ToCard).ToArray();
            foreach (var card in cards)
            {
                this.FoundCards.Add(card);
            }

            this.IsBusy = false;

            var newCardsImageUrlsList = new List<Tuple<int, string>>();

            foreach (var card in this.FoundCards)
            {
                if (!string.IsNullOrWhiteSpace(card.ImageUrl)) continue;

                var imageUrl = await this.CardImageService.GetImageUrlAsync(card.Name);

                card.ImageUrl = imageUrl;

                newCardsImageUrlsList.Add(Tuple.Create(card.Id, imageUrl));
            }

            foreach (var data in newCardsImageUrlsList)
            {
                await this.DataService.UpdateImageUrlAsync(data.Item1, data.Item2);
            }
        }

        private Card ToCard(Data.Models.Card card)
        {
            return new Card
            {
                Id = card.Id,
                Name = card.Name,
                Attribute = card.IsMonster() ? card.Attribute : card.Attribute.Split('/')[card.IsMagic() ? 0 : 1],
                CardTypes = card.IsMonster() ? card.Race + "/" + card.Type : card.Type,
                Attack = card.IsMonster() ? card.Attack < 0 ? "?" : card.Attack.ToString() : string.Empty,
                Defense = card.IsMonster() ? card.Defense < 0 ? "?" : card.Defense.ToString() : string.Empty,
                Type = card.GetCardType(),
                ImageUrl = card.ImageUrl
            };
        }

        public class Card : BaseViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string CardTypes { get; set; }

            public string Attribute { get; set; }

            public string Attack { get; set; }

            public string Defense { get; set; }

            public CardType Type { get; set; }

            private string imageUrl;
            public string ImageUrl
            {
                get { return imageUrl; }
                set { Set(nameof(ImageUrl), ref imageUrl, value); }
            }
        }
    }
}
