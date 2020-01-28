﻿using System;
using VehicleApps.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApps
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new SignupPage());
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
