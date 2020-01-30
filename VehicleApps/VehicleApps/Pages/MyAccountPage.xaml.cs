using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
	public partial class MyAccountPage : ContentPage
	{
        private MediaFile file { get; set; }
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

            file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            ImgProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                AddImageToServer();
                return stream;
            });
        }

        private async void AddImageToServer()
        {
            var imageArray = FromFile.ToArray(file.GetStream());
            file.Dispose();
            var response = await ApiService.EditUserProfile(imageArray);
            if (response) return;
            await DisplayAlert("Something wrong", "Please upload the image again", "Alright");
        }
    }
}