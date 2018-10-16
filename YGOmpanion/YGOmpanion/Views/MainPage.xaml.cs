﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YGOmpanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new SearchPage());
        }
    }
}