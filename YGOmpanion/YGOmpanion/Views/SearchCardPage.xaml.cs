using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YGOmpanion.ViewModels;

namespace YGOmpanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchCardPage : ContentPage
    {
        private SearchCardViewModel ViewModel
        {
            get { return this.BindingContext as SearchCardViewModel; }
        }

        public SearchCardPage()
        {
            InitializeComponent();
        }

        private void OnFoundCardsListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || !(e.SelectedItem is SearchCardViewModel.Card card)) return;

            this.ViewModel.GoToCard(card.Id);

            this.FoundCardsListView.SelectedItem = null;
        }
    }
}