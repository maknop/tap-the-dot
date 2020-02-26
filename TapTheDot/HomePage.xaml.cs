using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TapTheDot
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
                
        }


        void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();
        }

        
        public void ButtonSettings()
        {
            _ = new Button
            {
                Text = "Settings",

            };
        }
    }
}


        
       
 
