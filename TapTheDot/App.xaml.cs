using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TapTheDot
{
    public partial class App : Application
    {
        private static string filePath;

        public static string FilePath { get => filePath; internal set => filePath = value; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
