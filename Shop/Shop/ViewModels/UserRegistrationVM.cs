using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
	public class UserRegistrationVM
	{
		[Required(ErrorMessage = "Username is required!")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required!")]
		[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$", 
			ErrorMessage = "The password should be at least 6 symbols, containing lowercase letter(s), uppercase letter(s) and digits without spaces!")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Email is required!")]
		[EmailAddress(ErrorMessage = "Invalid E-mail!")]
		public string EmailAddress { get; set; }

		public string Address { get; set; }

		[Required(ErrorMessage = "Phone number is required!")]
		[RegularExpression(@"^\d{10}$", 
			ErrorMessage = "Phone number should contain only digits an its length should be 10 numbers!")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Bank account number is required!")]
		[RegularExpression(@"(^BG)([0-9]{2})([A-Z]{4})([0-9]{14}$)", 
			ErrorMessage = "Bank account number is not valid!")]
		public string BankAccountNumber { get; set; }
	}
}
