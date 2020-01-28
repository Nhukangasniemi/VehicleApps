using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VehicleApps.Models;
using Xamarin.Essentials;

namespace VehicleApps.Services
{
	public static class ApiService
	{
		public static async Task<bool> RegisterUser(string name, string email, string password)
		{
			var registerModel = new RegisterModel()
			{
				Name = name,
				Email = email,
				Password = password
			};

			var httpClient = new HttpClient();
			var json = JsonConvert.SerializeObject(registerModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync("https://xamarinvehicles.azurewebsites.net/api/accounts/register", content);
			if (!response.IsSuccessStatusCode) return false;
			return true;
		}

		public static async Task<bool> Login(string email, string password)
		{
			var loginModel = new LoginModel()
			{
				Email = email,
				Password = password
			};

			var httpClient = new HttpClient();
			var json = JsonConvert.SerializeObject(loginModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync("https://xamarinvehicles.azurewebsites.net/api/accounts/login", content);
			if (!response.IsSuccessStatusCode) return false;
			var jsonResult = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Token>(jsonResult);
			Preferences.Set("accessToken", result.access_token);
			return true;
		}

		[Authorize]
		public static async Task<bool> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
		{
			var changePasswordModel = new ChangePasswordModel()
			{
				OldPassword = oldPassword,
				NewPassword = newPassword,
				ConfirmPassword = confirmPassword
			};

			var httpClient = new HttpClient();
			var json = JsonConvert.SerializeObject(changePasswordModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue()
			var response = await httpClient.PostAsync("https://xamarinvehicles.azurewebsites.net/api/accounts/ChangePassword", content);
			if (!response.IsSuccessStatusCode) return false;
			return true;
		}
	}
}
