using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
	public class AdminVM
	{
		[Required(ErrorMessage = "Username is required!")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required!")]
		[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$",
			ErrorMessage = "The password should be at least 6 symbols, containing lowercase letter(s), uppercase letter(s) and digits without spaces!")]
		public string Password { get; set; }
	}
}
