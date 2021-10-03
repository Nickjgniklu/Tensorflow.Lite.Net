using System;
using System.Diagnostics;
using tensorflowlite_c;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tensorflow.Lite.Net.Forms
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            MainPage = new MainPage();

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
