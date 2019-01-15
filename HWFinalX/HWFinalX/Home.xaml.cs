using HWFinalX.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HWFinalX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
        Data data = Data.GetInstance();
        public Home ()
		{
			InitializeComponent ();
            int day = Int32.Parse(DateTime.Now.Day.ToString());
            Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => {
                    quote.Text = data.Quotes[day].quote;
                    owner.Text = "- " + data.Quotes[day].owner;
                    about.Text = "Welcome to the Star Wars Quick Guide. This application allows you to explore many things about the Star Wars " +
                    "universe. \n\nThere are " + data.Entities["Movies"].Count + " movies, " + data.Entities["Characters"].Count + " characters, " +
                    data.Entities["Planets"].Count + " planets, " + data.Entities["Species"].Count + " species, " + data.Entities["Starships"].Count +
                    " starships, and " + data.Entities["Vehicles"].Count + " vehicles waiting for you.\n\nAll data is inside the application. So " +
                    "you can use it without internet connection. You need internet to see images, though. You can also save images by double tapping" +
                    " them. \n\nThe application data is fetched from the Star Wars API (SWAPI) which contains information from Star " +
                    "Wars Canon Universe (Disney Canon). Unfortunately, the information about the expanded universe (Legends) is not available " +
                    "for now (Sorry in advance if you were about to look for Darth Revan).";
                });
            });
		}
	}
}