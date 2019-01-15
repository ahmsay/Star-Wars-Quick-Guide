using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;
using HWFinalX.AppData;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace HWFinalX
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
            string platform = "";
            if (Device.RuntimePlatform == Device.Android)
                platform = "Droid";
            else if (Device.RuntimePlatform == Device.iOS)
                platform = "iOS";
            else if (Device.RuntimePlatform == Device.UWP)
                platform = "UWP";

            Data data = Data.GetInstance();
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("HWFinalX." + platform + ".AppData.EmbeddedData.json");
            if (stream != null && data.Entities["Movies"].Count == 0)
            {
                using (var reader = new StreamReader(stream))
                {
                    string s = reader.ReadToEnd();
                    var x = JsonConvert.DeserializeObject<Data>(s);

                    data.Quotes = x.Quotes;
                    data.Entities["Movies"].AddRange(x.Movies);
                    data.Entities["Characters"].AddRange(x.Characters);
                    data.Entities["Planets"].AddRange(x.Planets);
                    data.Entities["Species"].AddRange(x.Species);
                    data.Entities["Starships"].AddRange(x.Starships);
                    data.Entities["Vehicles"].AddRange(x.Vehicles);
                }
                if (Current.Properties.ContainsKey("fav"))
                {
                    var s = (string)Current.Properties["fav"];
                    var x = JsonConvert.DeserializeObject<Data>(s);

                    data.Entities["Favorites"].AddRange(x.Movies);
                    data.Entities["Favorites"].AddRange(x.Characters);
                    data.Entities["Favorites"].AddRange(x.Planets);
                    data.Entities["Favorites"].AddRange(x.Species);
                    data.Entities["Favorites"].AddRange(x.Starships);
                    data.Entities["Favorites"].AddRange(x.Vehicles);

                    FavData fav = FavData.GetInstance();

                    fav.Entities["Movies"].AddRange(x.Movies);
                    fav.Entities["Characters"].AddRange(x.Characters);
                    fav.Entities["Planets"].AddRange(x.Planets);
                    fav.Entities["Species"].AddRange(x.Species);
                    fav.Entities["Starships"].AddRange(x.Starships);
                    fav.Entities["Vehicles"].AddRange(x.Vehicles);
                }
            }
        }

		protected override void OnSleep ()
		{

		}

		protected override void OnResume ()
		{

		}
	}
}
