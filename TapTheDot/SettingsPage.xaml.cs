using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TapTheDot
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        void NavigateButton_OnClicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePage();
        }
    }
}
