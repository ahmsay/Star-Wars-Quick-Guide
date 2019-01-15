using HWFinalX.Helpers;
using HWFinalX.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageSaver))]
namespace HWFinalX.UWP
{
    public class ImageSaver : IImageSaver
    {
        public async void Save(string url, string filename)
        {
            StorageFile file = await DownloadsFolder.CreateFileAsync(filename + ".png", CreationCollisionOption.GenerateUniqueName);
            HttpClient client = new HttpClient();
            byte[] buffer = await client.GetByteArrayAsync(url);
            using (Stream stream = await file.OpenStreamForWriteAsync())
                stream.Write(buffer, 0, buffer.Length);
        }
    }
}
