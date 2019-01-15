using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using HWFinalX.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using Newtonsoft.Json;
using HWFinalX.AppData;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;
using HWFinalX.Helpers;

namespace HWFinalX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntityDetail : ContentPage
	{
        Data data = Data.GetInstance();
        FavData favdata = FavData.GetInstance();
        EntityList listpage;
        public SharpEntity ent;
        public string type;
        public bool added;
        CustomButton add;
        CustomButton remove;
        CustomButton more;
        public EntityDetail (EntityList listpage, SharpEntity ent, string type)
		{
            InitializeComponent();
            this.listpage = listpage;
            this.ent = ent;
            this.type = type;
            Title = ent.name;
            img.Source = ent.img_url != "" ? img.Source = new UriImageSource { Uri = new Uri(ent.img_url), CachingEnabled = true, CacheValidity = new TimeSpan(0, 3, 0) } : img.Source = "http://www.linuxcmd.org/lcshow/big/69/691161_star-wars-logo-wallpaper.jpg";
            added = data.Entities["Favorites"].Any(x => x.name == ent.name) ? true : false;

            PropertyDescriptorCollection c = TypeDescriptor.GetProperties(ent);
            for (int i = 0; i < c.Count-3; i++)
            {
                var formattedString = new FormattedString();
                formattedString.Spans.Add(new Span { Text = ent.displaynames[i] + ": ", ForegroundColor = (Color)Application.Current.Resources["swyellow"] });
                formattedString.Spans.Add(new Span { Text = c[i].GetValue(ent).ToString() });
                stack.Children.Add(new Label { TextColor = (Color)Application.Current.Resources["swlightgray"], FormattedText = formattedString });
            }

            add = new CustomButton { Text = "ADD TO FAVORITES", IsVisible = !added };
            remove = new CustomButton { Text = "REMOVE FROM FAVORITES", IsVisible = added };
            more = new CustomButton { Text = "MORE INFO" };

            add.Style = new Style(typeof(CustomButton)) { BaseResourceKey = "buttonStyle" };
            remove.Style = new Style(typeof(CustomButton)) { BaseResourceKey = "buttonStyle" };
            more.Style = new Style(typeof(CustomButton)) { BaseResourceKey = "buttonStyle" };

            add.Clicked += AddFavorites;
            remove.Clicked += Remove;
            more.Clicked += MoreInfo;

            StackLayout buttons = new StackLayout { VerticalOptions = LayoutOptions.EndAndExpand };
            buttons.Children.Add(add);
            buttons.Children.Add(remove);
            buttons.Children.Add(more);
            stack.Children.Add(buttons);
        }

        public async void AddFavorites(object sender, EventArgs e)
        {
            if (data.Entities["Favorites"].Count < 20)
            {
                if (!added)
                {
                    added = true;
                    data.Entities["Favorites"].Add(ent);
                    favdata.Entities[type].Add(ent);
                    add.IsVisible = !added;
                    remove.IsVisible = added;

                    var x = JsonConvert.SerializeObject(favdata.Entities);
                    if (Application.Current.Properties.ContainsKey("fav"))
                        Application.Current.Properties["fav"] = x;
                    else
                        Application.Current.Properties.Add("fav", x);
                    listpage.Refresh(this, null);
                    await Application.Current.SavePropertiesAsync();
                }
            } else
            {
                await DisplayAlert("Error", "According to the imperial laws, you can't have more than 20 favorites.", "OK");
            }
        }

        public async void Remove(object sender, EventArgs e)
        {
            if (added)
            {
                added = false;
                data.Entities["Favorites"].RemoveAll(r => r.name == ent.name);
                foreach (KeyValuePair<string, List<SharpEntity>> f in favdata.Entities)
                {
                    int removed = favdata.Entities[f.Key].RemoveAll(t => t.name == ent.name);
                    if (removed == 1)
                    {
                        type = f.Key;
                        break;
                    }
                }
                add.IsVisible = !added;
                remove.IsVisible = added;

                var x = JsonConvert.SerializeObject(favdata.Entities);
                Application.Current.Properties["fav"] = x;
                listpage.Refresh(this, null);
                await Application.Current.SavePropertiesAsync();
            }
        }

        public void MoreInfo(object sender, EventArgs e)
        {
            string query = ent.name;
            query.Replace(" ", "+");
            Device.OpenUri(new Uri("https://www.google.com/search?q=star+wars+" + query.ToLower()));
        }

        public async void Save(object sender, EventArgs e)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                        await DisplayAlert("Info", "Storage permission is needed to save the image.", "OK");

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

                    if (results.ContainsKey(Permission.Storage))
                        status = results[Permission.Storage];
                }
                if (status == PermissionStatus.Granted)
                {
                    string filename = ent.name;
                    filename.Replace(" ", "_");
                    System.Diagnostics.Debug.WriteLine(filename);
                    var saver = DependencyService.Get<IImageSaver>();
                    if (saver != null)
                        saver.Save(ent.img_url, filename);
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Error", "Storage permission is needed to save the image.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }
        }
    }
}