﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using YGOmpanion.Data.Models;
using YGOmpanion.Data.Services;
using YGOmpanion.Services;

namespace YGOmpanion.ViewModels
{
    public class SearchCardViewModel : BaseViewModel
    {
        private readonly IDataService DataService;
        private readonly ICardImageService CardImageService;

        public SearchCardViewModel(
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
        }

        private Card ToCard(Data.Models.Card card)
        {
            return new Card
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                Attribute = card.GetAttribute(),
                CardTypes = card.GetCardTypes(),
                Attack = card.GetAttack(),
                Defense = card.GetDefense(),
                Type = card.GetCardType(),
                IsMonster = card.IsMonster(),
                ImageUrl = card.ImageUrl
            };
        }

        public async void GoToCard(int id)
        {
            await this.NavigationService.NavigateAsync(nameof(Views.CardDetailPage), id);
        }
        
        public class Card
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
            
            public string ImageUrl { get; set; }
        }
    }
}
