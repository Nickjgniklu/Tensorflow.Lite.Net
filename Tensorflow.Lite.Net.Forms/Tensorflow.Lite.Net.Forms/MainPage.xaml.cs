using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using SkiaSharp;
using Xamarin.Forms;
using Tensorflow.Lite.Net;
using Tensorflow.Lite.Net.Forms.Data.MnistImages;
using tensorflowlite_c;

namespace Tensorflow.Lite.Net.Forms
{
    public partial class MainPage : ContentPage
    {
        private sbyte[] currentImage;
        private int imagesIndex = 0;
        private TfLiteModel model;
        private TfLiteInterpreterOptions options;
        private TfLiteInterpreter interpreter;
        public MainPage()
        {
            InitializeComponent();
            currentImage = Data.MnistImages.Data.Images[imagesIndex];
            createModel();
            createInterpreterOptions();
            createInterpreter();
        }

        private void createInterpreter()
        {
            interpreter = c_api.TfLiteInterpreterCreate(model, options);
            c_api.TfLiteInterpreterAllocateTensors(interpreter);
        }

        private void createInterpreterOptions()
        {
            options = c_api.TfLiteInterpreterOptionsCreate();
            c_api.TfLiteInterpreterOptionsSetNumThreads(options, 2);
        }

        private void createModel()
        {
            // Debug.WriteLine($"TfLiteVersion: {c_api.TfLiteVersion()}");

            var modelBytes = GetModelBytesFromResource("MLModels.mnist.tflite");
            GCHandle modelHandle = GCHandle.Alloc(modelBytes, GCHandleType.Pinned);
            IntPtr modelpointer = modelHandle.AddrOfPinnedObject();
            model = c_api.TfLiteModelCreate(modelpointer, (ulong)modelBytes.Length);
        }
        ~MainPage()
        {
            c_api.TfLiteInterpreterDelete(interpreter);
            c_api.TfLiteModelDelete(model);
            c_api.TfLiteInterpreterOptionsDelete(options);
        }
        protected override void OnAppearing()
        {
            VersionLabel.Text = $"tflite version {c_api.TfLiteVersion()}";
            CanvasView.PaintSurface += CanvasView_PaintSurface;


        }

        private SKBitmap grayScaleArrayToBitmap(sbyte[] data, int width, int height)
        {
            var bitMap = new SKBitmap(new SKImageInfo(width, height, SKColorType.Gray8));
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var colorByte = (byte)(data[j * width + i] + 128);
                    bitMap.SetPixel(i, j, new SKColor(colorByte, colorByte, colorByte));

                }
            }
            return bitMap;
        }

        private void CanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            var bitmap = grayScaleArrayToBitmap(currentImage, 28, 28);
            canvas.DrawBitmap(bitmap, new SKRect(0, 0, info.Width, info.Height));
        }

        //
        private byte[] GetModelBytesFromResource(string resourceName)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            var d = assembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{resourceName}");
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        private void Button_OnClicked(object sender, EventArgs e)
        {



            GCHandle imageHandle = GCHandle.Alloc(currentImage, GCHandleType.Pinned);
            TfLiteTensor inputTensor = c_api.TfLiteInterpreterGetInputTensor(interpreter, 0);
            IntPtr inputPointer = imageHandle.AddrOfPinnedObject();
            c_api.TfLiteTensorCopyFromBuffer(inputTensor, inputPointer, 28 * 28);
            TfLiteStatus status = c_api.TfLiteInterpreterInvoke(interpreter);
            TfLiteTensor outputTensor = c_api.TfLiteInterpreterGetOutputTensor(interpreter, 0);
            sbyte[] dataout = new sbyte[10];
            GCHandle pinnedArray = GCHandle.Alloc(dataout, GCHandleType.Pinned);
            IntPtr outputPointer = pinnedArray.AddrOfPinnedObject();
            c_api.TfLiteTensorCopyToBuffer(outputTensor, outputPointer, 10);
            Result.Text = $"Predicted {dataout.IndexOf(dataout.Max())}";
            imageHandle.Free();
            pinnedArray.Free();

        }

        private void NextImage(object sender, EventArgs e)
        {
            currentImage = Data.MnistImages.Data.Images[++imagesIndex % Data.MnistImages.Data.Images.Count];
            CanvasView.InvalidateSurface();
            Result.Text = "";
        }
    }

}
