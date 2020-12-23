using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Base_XF.ViewModel.LoginViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Base_XF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		public MoviePage()
		{
			InitializeComponent ();
		}

        void CustomEntryControl_TextChanged(Object sender, TextChangedEventArgs e)
        {
			string searchText = ((Entry)sender).Text;
			((MovieViewModel)BindingContext).IsVisible = !string.IsNullOrEmpty(searchText);

			if (string.IsNullOrEmpty(searchText))
				((MovieViewModel)BindingContext).TapImageCommand.Execute(sender);

			if (searchText.Length > 2) 
				((MovieViewModel)BindingContext).SearchCommand.Execute(searchText);
			

		}
    }
}