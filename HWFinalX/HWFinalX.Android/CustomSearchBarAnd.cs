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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HWFinalX.CustomControls;
using HWFinalX.Droid;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarAnd))]
namespace HWFinalX.Droid
{
    public class CustomSearchBarAnd: SearchBarRenderer
    {
        public CustomSearchBarAnd(Context context): base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            var searchIconId = Control.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
            if (searchIconId > 0)
            {
                var searchPlateIcon = Control.FindViewById(searchIconId);
                (searchPlateIcon as ImageView).SetColorFilter(Android.Graphics.Color.Argb(255, 254, 226, 26));
            }
        }
    }
}