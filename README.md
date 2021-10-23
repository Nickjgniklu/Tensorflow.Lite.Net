# Tensorflow c_api for .NET
This library was created using [cppsharp](https://github.com/mono/CppSharp). Currently the only api exposed by this library must be used in an unsafe context.

## Currently Supported Platforms
* Android
* Windows x64 
## Unsupported Platforms
* Linux x64
* iOS
* macOS
* UWP 

All platforms except UWP appear to be implementable and will be added in the future
## Examples
* TensorflowLite.Net.Forms is a simple mnist example
## Usage
### Load tflite model as bytes
```
var modelBytes = File.ReadAllBytes("MLModels.mnist.tflite")
```
### Create Model
```
GCHandle modelHandle = GCHandle.Alloc(modelBytes, GCHandleType.Pinned);
IntPtr modelpointer = modelHandle.AddrOfPinnedObject();
TfLiteModel model = c_api.TfLiteModelCreate(modelpointer, (ulong)modelBytes.Length);
```
### Create Interpreter with options
```
 TfLiteInterpreterOptions options = c_api.TfLiteInterpreterOptionsCreate();
 c_api.TfLiteInterpreterOptionsSetNumThreads(options, 2);
 TfLiteInterpreter interpreter = c_api.TfLiteInterpreterCreate(model, options);
 c_api.TfLiteInterpreterAllocateTensors(interpreter);
```
### Run inference
```
sbyte[] currentImage=new sbyte[28*28];
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
```
### Clean up
If you fail to call these functions after use you may cause memory leaks
```
c_api.TfLiteInterpreterDelete(interpreter);
c_api.TfLiteModelDelete(model);
c_api.TfLiteInterpreterOptionsDelete(options);
```


## Future Tasks
* Support iOS, macOS, and Linux x64
* Create higher level api to mask unsafe classes
* examples for multidimensional inputs and outputs
* does the c_api support gpu?
