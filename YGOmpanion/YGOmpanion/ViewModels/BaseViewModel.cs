namespace YGOmpanion.ViewModels
{
    public class BaseViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { Set(nameof(IsBusy), ref isBusy, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { Set(nameof(Title), ref title, value); }
        }
    }
}
