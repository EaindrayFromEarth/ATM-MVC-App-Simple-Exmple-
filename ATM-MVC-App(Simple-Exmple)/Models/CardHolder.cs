using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM_MVC_App_Simple_Exmple_.Models;

public partial class CardHolder
{
    public int CardHolderId { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Card Number is required")]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "Card Number must be 16 digits")]
    public string CardNumber { get; set; } = null!;

    [Required(ErrorMessage = "PIN Number is required")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN Number must be 4 digits")]
    public string Pinnumber { get; set; } = null!;

    public decimal Balance { get; set; }
}
