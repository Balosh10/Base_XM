namespace App_Base_XF.Bases.CustomRender
{
    using Xamarin.Forms;
    public class CustomEntryControl : Entry
    {
        public static readonly BindableProperty FontSizeScaledProperty = BindableProperty.Create(
            nameof(FontSizeScaled),
            typeof(double),
            typeof(CustomEntryControl),
            default(double),
            BindingMode.OneWay,
            null,
            (bindable, oldValue, newValue) => { if (oldValue == newValue) return; ((CustomEntryControl)bindable).OnFontSizeScaledPropertyChanged(); }
        );

        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create(
            nameof(HasBorder),
            typeof(bool),
            typeof(CustomEntryControl),
            default(bool),
            BindingMode.OneWay,
            null
        );

        public double FontSizeScaled
        {
            get { return (double)GetValue(FontSizeScaledProperty); }
            set { SetValue(FontSizeScaledProperty, value); }
        }

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        public const string Typeface = "FontAwesome";

        public CustomEntryControl()
        {
            FontFamily = Typeface;
            HasBorder = false;
        }

        private void OnFontSizeScaledPropertyChanged()
        {
            if (App.DisplayScreenInches >= 7.0)
            {
                if (Device.RuntimePlatform == Device.Android)
                    this.FontSize = this.FontSizeScaled * (App.DisplayScreenInches - 3);
                else
                    this.FontSize = this.FontSizeScaled * (App.DisplayScreenInches + 2);
            }
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                    this.FontSize = this.FontSizeScaled * App.DisplayScreenInches - 2;
                else
                    this.FontSize = this.FontSizeScaled * App.DisplayScreenInches + 1;
            }
        }
    }
}