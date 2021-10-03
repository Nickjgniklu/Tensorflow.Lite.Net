﻿using System;
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
using tensorflowlite_c;

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
//            var model = c_api.TfLiteModelCreateFromFile("./mnist.tflite");
//            var options = c_api.TfLiteInterpreterOptionsCreate();
//            c_api.TfLiteInterpreterOptionsSetNumThreads(options, 2);
//            var interpreter = c_api.TfLiteInterpreterCreate(model, options);
//            c_api.TfLiteInterpreterAllocateTensors(interpreter);
//            sbyte[] datain = new sbyte[]
////1
//{
// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,   12,   44, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -116,  126,  113,  -82, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,   10,  126,  101, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -107,  116,  126,   78, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,   10,  125,  118,  -97, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  103,  126,  116, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,  114, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,   33, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,   -6, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  102,  125,   -6, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  -48,  121,  125,   -6, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,   15,  125,  125,  -53, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,   90,  125,   15, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,  -72,  114,  -53, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


// -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128, -128,


//}; ;


//            GCHandle inputhandle = GCHandle.Alloc(datain, GCHandleType.Pinned);
//            var input = c_api.TfLiteInterpreterGetInputTensor(interpreter, 0);
//            IntPtr inputpointer = inputhandle.AddrOfPinnedObject();
//            c_api.TfLiteTensorCopyFromBuffer(input, inputpointer, 28 * 28);
//            var status = c_api.TfLiteInterpreterInvoke(interpreter);
//            var output = c_api.TfLiteInterpreterGetOutputTensor(interpreter, 0);
//            sbyte[] dataout = new sbyte[10];


//            GCHandle pinnedArray = GCHandle.Alloc(dataout, GCHandleType.Pinned);
//            IntPtr pointer = pinnedArray.AddrOfPinnedObject();
//            c_api.TfLiteTensorCopyToBuffer(output, pointer, 10);
//        }
//
private void Button_OnClicked(object sender, EventArgs e)
{
            // Debug.WriteLine($"TfLiteVersion: {c_api.TfLiteVersion()}");
               versionLavel.Text=c_api.TfLiteVersion();
          //  var myMathFuncs = new MyMathFuncs();
            //myMathFuncs.Add(2, 5).ToString();


}
    }
}
