﻿using System;
using VehicleApps.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApps
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var accessToken = Preferences.Get("accessToken", string.Empty);
			if (string.IsNullOrEmpty(accessToken))
			{
				MainPage = new NavigationPage(new SignupPage());
			}
			else 
			{
				MainPage = new NavigationPage(new HomePage());
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
