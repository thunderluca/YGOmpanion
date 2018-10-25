using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YGOmpanion.ViewModels;

namespace YGOmpanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardDetailPage : ContentPage
    {
        private CardDetailViewModel ViewModel
        {
            get { return this.BindingContext as CardDetailViewModel; }
        }

        public CardDetailPage(int id)
        {
            InitializeComponent();

            this.ViewModel.Load(id);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.MainParallaxView.DestroyParallaxView();
        }
    }
}