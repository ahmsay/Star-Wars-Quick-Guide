using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWFinalX.AppData;
using Entities;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HWFinalX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntityList : ContentPage
	{
        Data data = Data.GetInstance();
        public string type;
        public EntityList (string type)
		{
			InitializeComponent();
            this.type = type;
            Title = type;
            entityList.ItemsSource = new List<SharpEntity>();
            Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => { entityList.ItemsSource = data.Entities[type]; });
            });
        }

        public async void Display(object sender, ItemTappedEventArgs e)
        {
            var ent = (SharpEntity)e.Item;
            await Navigation.PushAsync(new EntityDetail(this, ent, type));
        }

        public void Search(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
                entityList.ItemsSource = data.Entities[type];
            else
                entityList.ItemsSource = data.Entities[type].Where(x => x.name.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        public void Refresh(object sender, EventArgs e)
        {
            entityList.ItemsSource = new List<SharpEntity>();
            entityList.ItemsSource = data.Entities[type];
        }
    }
}