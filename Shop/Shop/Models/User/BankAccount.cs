﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.User
{
	public class BankAccount
	{
		[Key]
		public string BankAccountNumber { get; set; }

		[Column(TypeName = "decimal(10, 2)")]
		public decimal BankAccountBalance { get; set; }

		[Required]
		public User User { get; set; }
	}
}
