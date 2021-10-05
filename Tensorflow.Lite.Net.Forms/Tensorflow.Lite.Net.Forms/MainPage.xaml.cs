using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathFuncs;
using Xamarin.Forms;
using Tensorflow.Lite.Net;
using Tensorflow.Lite.Net.Forms.Data.MnistImages;
using tensorflowlite_c;

//using tensorflowlite_c;

namespace Tensorflow.Lite.Net.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
            }
            catch (Exception e)
            {

            }
        }

//
private void Button_OnClicked(object sender, EventArgs e)
{
            // Debug.WriteLine($"TfLiteVersion: {c_api.TfLiteVersion()}");
            versionLavel.Text=c_api.TfLiteVersion();
            GCHandle inputhandle = GCHandle.Alloc(Images.Number1, GCHandleType.Pinned);

            var model = c_api.TfLiteModelCreateFromFile("./mnist.tflite");
            var options = c_api.TfLiteInterpreterOptionsCreate();
            c_api.TfLiteInterpreterOptionsSetNumThreads(options, 2);
            var interpreter = c_api.TfLiteInterpreterCreate(model, options);
            c_api.TfLiteInterpreterAllocateTensors(interpreter);
             ;


            var input = c_api.TfLiteInterpreterGetInputTensor(interpreter, 0);
            IntPtr inputpointer = inputhandle.AddrOfPinnedObject();
            c_api.TfLiteTensorCopyFromBuffer(input, inputpointer, 28 * 28);
            var status = c_api.TfLiteInterpreterInvoke(interpreter);
            var output = c_api.TfLiteInterpreterGetOutputTensor(interpreter, 0);
            sbyte[] dataout = new sbyte[10];


            GCHandle pinnedArray = GCHandle.Alloc(dataout, GCHandleType.Pinned);
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();
            c_api.TfLiteTensorCopyToBuffer(output, pointer, 10);
        }
    }
    
}
