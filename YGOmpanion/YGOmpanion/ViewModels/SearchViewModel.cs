using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using YGOmpanion.Data;
using YGOmpanion.Data.Models;

namespace YGOmpanion.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly Database Database;

        public SearchViewModel(Database database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));

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

        private void Search()
        {
            if (IsBusy) return;

            IsBusy = true;

            this.FoundCards.Clear();

            if (string.IsNullOrWhiteSpace(this.Query))
            {
                IsBusy = false;
                return;
            }

            var foundCards = Database.CardData.Contains(this.Query).Select(ToCard).ToArray();
            if (foundCards?.Length == 0)
            {
                IsBusy = false;
                return;
            }

            foreach (var card in foundCards)
            {
                this.FoundCards.Add(card);
            }

            IsBusy = false;
        }

        private static Card ToCard(CardDataRow card)
        {
            return new Card
            {
                Name = card.CardName,
                Attribute = card.Attribute,
                MonsterTypes = string.Join("/", card.CardMonsterTypes),
                Attack = string.IsNullOrWhiteSpace(card.Attack) ? "-" : card.Attack.Trim(),
                Defense = string.IsNullOrWhiteSpace(card.Defense) ? "-" : card.Defense.Trim(),
                Type = card.CardType
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
        }
    }
}
