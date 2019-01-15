using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HWFinalX
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
            Detail = new NavigationPage(new Home());
            IsPresented = false;
            if (DateTime.Now.Day == 4 && DateTime.Now.Month == 5)
                celeb.IsVisible = true;
        }

        private void Switch(object sender, ItemTappedEventArgs e)
        {
            string s = (string)e.Item;
            switch (s)
            {
                case "Home":
                    Detail = new NavigationPage(new Home());
                    break;
                case "Movies":
                    Detail = new NavigationPage(new EntityList("Movies"));
                    break;
                case "Characters":
                    Detail = new NavigationPage(new EntityList("Characters"));
                    break;
                case "Planets":
                    Detail = new NavigationPage(new EntityList("Planets"));
                    break;
                case "Species":
                    Detail = new NavigationPage(new EntityList("Species"));
                    break;
                case "Starships":
                    Detail = new NavigationPage(new EntityList("Starships"));
                    break;
                case "Vehicles":
                    Detail = new NavigationPage(new EntityList("Vehicles"));
                    break;
                case "My Favorites":
                    Detail = new NavigationPage(new EntityList("Favorites"));
                    break;
            }
            IsPresented = false;
        }
    }
}
