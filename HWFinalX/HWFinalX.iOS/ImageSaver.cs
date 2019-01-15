using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using HWFinalX.Helpers;
using HWFinalX.iOS;
using System.Net;
using System.IO;

[assembly: Dependency(typeof(ImageSaver))]
namespace HWFinalX.iOS
{
    public class ImageSaver : IImageSaver
    {
        public void Save(string url, string filename)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += (s, e) => {
                var bytes = e.Result;
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string localFilename = filename + ".png";
                string localPath = Path.Combine(documentsPath, localFilename);
                File.WriteAllBytes(localPath, bytes);
            };
            webClient.DownloadDataAsync(new Uri(url));
        }
    }
}