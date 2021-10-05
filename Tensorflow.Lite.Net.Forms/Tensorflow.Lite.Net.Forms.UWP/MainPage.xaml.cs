using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using tensorflowlite_c;

namespace Tensorflow.Lite.Net.Forms.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            //LoadApplication(new Tensorflow.Lite.Net.Forms.App());

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var file in Directory.GetFiles("./lib/x64").Concat(Directory.GetDirectories("./lib/x64")))
            {
                Debug.WriteLine(file);
            }
            Debug.WriteLine(c_api.TfLiteVersion());
        }
    }
}
