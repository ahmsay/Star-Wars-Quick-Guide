using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HWFinalX.Droid;
using Xamarin.Forms;
using Android.Graphics;
using System.IO;
using System.Net;
using HWFinalX.Helpers;

[assembly: Dependency(typeof(ImageSaver))]
namespace HWFinalX.Droid
{
    public class ImageSaver : IImageSaver
    {
        public void Save(string url, string filename)
        {
            Bitmap b = GetImageBitmapFromUrl(url);
            ExportBitmapAsPNG(b, filename);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Java.IO.File f = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Download/" + filename + ".png");
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(f);
            mediaScanIntent.SetData(contentUri);
            Android.App.Application.Context.SendBroadcast(mediaScanIntent);
            Toast.MakeText(Android.App.Application.Context, "Saved to Gallery", ToastLength.Long).Show();
        }

        public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            }
            return imageBitmap;
        }

        public async void ExportBitmapAsPNG(Bitmap bitmap, string filename)
        {
            var folderPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Download";
            var filePath = System.IO.Path.Combine(folderPath, filename + ".png");
            var stream = new FileStream(filePath, FileMode.Create);
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
        }
    }
}