using System;
using Android.Content;
using Android.Graphics.Drawables;
using App_Base_XF.Bases.CustomRender;
using App_Base_XF.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntryControl), typeof(EntryCustomRenderer))]
namespace App_Base_XF.Droid.CustomRenderers
{
    public class EntryCustomRenderer : EntryRenderer
    {
        public EntryCustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                if (Element != null && Element is CustomEntryControl && !((CustomEntryControl)Element).HasBorder)
                {
                    GradientDrawable gradientDrawable = new GradientDrawable();
                    gradientDrawable.SetColor(global::Android.Graphics.Color.Transparent);
                    Control.Background = gradientDrawable;
                }
            }
        }
    }
}