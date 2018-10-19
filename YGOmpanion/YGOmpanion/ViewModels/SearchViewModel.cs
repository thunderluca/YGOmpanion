using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
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

            SearchCommand = new Command(Search);
        }

        string query = string.Empty;
        public string Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
        }

        public ObservableCollection<Card> FoundCards { get; set; }

        public ICommand SearchCommand { get; }

        private async void Search()
        {
            if (IsBusy) return;

            IsBusy = true;

            this.FoundCards.Clear();

            if (string.IsNullOrWhiteSpace(this.Query))
            {
                IsBusy = false;
                return;
            }

            var foundCards = await DataService.SearchAsync(this.Query);
            if (foundCards?.Count == 0)
            {
                IsBusy = false;
                return;
            }

            var cards = foundCards.Select(this.ToCard).ToArray();
            foreach (var card in cards)
            {
                this.FoundCards.Add(card);
            }

            IsBusy = false;
        }

        private Card ToCard(Data.Models.Card card)
        {
            return new Card
            {
                Name = card.Name,
                Attribute = card.Attribute,
                MonsterTypes = card.Race + "/" + card.Type,
                Attack = card.IsMonster() ? card.Attack < 0 ? "?" : card.Attack.ToString() : string.Empty,
                Defense = card.IsMonster() ? card.Defense < 0 ? "?" : card.Defense.ToString() : string.Empty,
                Type = card.GetCardType(),
                ImageUrl = card.ImageUrl
            };
        }

        public class Card
        {
            public string Name { get; set; }

            public string MonsterTypes { get; set; }

            public string Attribute { get; set; }

            public string Attack { get; set; }

            public string Defense { get; set; }

            public CardType Type { get; set; }

            public string ImageUrl { get; set; }
        }
    }
}
