using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
	public class UserLoginVM
	{
		[Required(ErrorMessage = "Username is required!")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required!")]
		public string Password { get; set; }
	}
}
