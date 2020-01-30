using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApps.Models
{
	public class UserImageModel
	{
		public string imageUrl { get; set; }
		public string FullImagePath => $"https://xamarinvehicles.azurewebsites.net/{imageUrl}";
	}
}
