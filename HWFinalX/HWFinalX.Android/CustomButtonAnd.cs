using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HWFinalX.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HWFinalX.Droid;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonAnd))]
namespace HWFinalX.Droid
{
    class CustomButtonAnd: ButtonRenderer
    {
        public CustomButtonAnd(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var control = e.NewElement as CustomButton;
            if (control != null)
            {
                if (control.TintColor != Xamarin.Forms.Color.Default)
                {
                    var androidColor = control.TintColor.ToAndroid();
                    Control.Background.SetColorFilter(androidColor, PorterDuff.Mode.Src);
                }
            }
        }
    }
}