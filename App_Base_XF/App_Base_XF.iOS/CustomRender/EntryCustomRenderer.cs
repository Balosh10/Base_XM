using System;
using App_Base_XF.Bases.CustomRender;
using App_Base_XF.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryControl), typeof(EntryCustomRenderer))]
namespace App_Base_XF.iOS.CustomRenderers
{
    public class EntryCustomRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                if (Element != null && Element is CustomEntryControl && !((CustomEntryControl)Element).HasBorder)
                {
                    Control.BorderStyle = UITextBorderStyle.None;
                }
            }
        }
    }
}