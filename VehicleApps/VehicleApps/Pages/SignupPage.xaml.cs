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
	public partial class SignupPage : ContentPage
	{
		public SignupPage()
		{
			InitializeComponent();
		}

		private async void BtnSignUp_Clicked(object sender, EventArgs e)
		{
			var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
			if (response)
			{
				await DisplayAlert("Hi", "Your account has been created", "Alright");
				Navigation.PushModalAsync(new LoginPage());
			}
			else
			{
				await DisplayAlert("Oops", "Something went wrong", "Cancel");
			}
		}
	}
}