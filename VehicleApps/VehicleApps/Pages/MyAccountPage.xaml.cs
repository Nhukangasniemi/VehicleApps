using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApps.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyAccountPage : ContentPage
	{
		public MyAccountPage()
		{
			InitializeComponent();
		}

		private void TapUploadImage_Tapped(object sender, EventArgs e)
		{
			PickImageFromGallery();
		}

		private async void PickImageFromGallery()
		{
            await CrossMedia.Current.Initialize();

            if ( !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("Oops", "Your device does not support this feature", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            ImgProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
	}
}