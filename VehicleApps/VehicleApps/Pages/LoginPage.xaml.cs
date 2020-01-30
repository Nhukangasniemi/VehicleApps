using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApps.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApps.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		private void BtnBack_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

		private async void BtnLogin_Clicked(object sender, EventArgs e)
		{
			var res = await ApiService.Login(EntEmail.Text, EntPassword.Text);
			if (res)
			{
				//Set the HomePage to be main page. Then after login, user can't go back to login page
				Application.Current.MainPage = new NavigationPage(new HomePage());
			}
			else {
				await DisplayAlert("Oops", "Something went wrong", "Cancel");
			}
		}
	}
}