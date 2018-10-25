using System;
using GalaSoft.MvvmLight.Views;
using YGOmpanion.Data.Models;
using YGOmpanion.Data.Services;

namespace YGOmpanion.ViewModels
{
    public class CardDetailViewModel : BaseViewModel
    {
        private readonly IDataService DataService;

        public CardDetailViewModel(IDataService dataService, IDialogService dialogService, Services.INavigationService navigationService) : base(dialogService, navigationService)
        {
            this.DataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { Set(nameof(Id), ref id, value); }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { Set(nameof(Name), ref name, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { Set(nameof(Description), ref description, value); }
        }

        private string cardTypes = string.Empty;
        public string CardTypes
        {
            get { return cardTypes; }
            set { Set(nameof(CardTypes), ref cardTypes, value); }
        }

        private string attribute = string.Empty;
        public string Attribute
        {
            get { return attribute; }
            set { Set(nameof(Attribute), ref attribute, value); }
        }

        private string attack = string.Empty;
        public string Attack
        {
            get { return attack; }
            set { Set(nameof(Attack), ref attack, value); }
        }

        private string defense = string.Empty;
        public string Defense
        {
            get { return defense; }
            set { Set(nameof(Defense), ref defense, value); }
        }

        private CardType type = CardType.Unknown;
        public CardType Type
        {
            get { return type; }
            set { Set(nameof(Type), ref type, value); }
        }

        private string imageUrl = string.Empty;
        public string ImageUrl
        {
            get { return imageUrl; }
            set { Set(nameof(ImageUrl), ref imageUrl, value); }
        }

        public async void Load(int id)
        {
            if (this.IsBusy) return;

            this.IsBusy = true;

            var card = await this.DataService.GetCardAsync(id);
            if (card == null)
            {
                this.IsBusy = false;
                await this.DialogService.ShowError("Card not found", "Error", "OK", GoBack);
                return;
            }
            
            this.Id = card.Id;
            this.Name = card.Name;
            this.Description = card.Description;
            this.Attribute = card.GetAttribute();
            this.CardTypes = card.GetCardTypes();
            this.Attack = card.GetAttack();
            this.Defense = card.GetDefense();
            this.Type = card.GetCardType();
            this.ImageUrl = card.ImageUrl;
            this.Title = card.Name;

            this.IsBusy = false;
        }
    }
}
