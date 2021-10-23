using System;
using tensorflowlite_c;

namespace Tensorflow.Net.Lite.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"TF Lite Version {c_api.TfLiteVersion()}");
        }
    }
}
