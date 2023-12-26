using System;
using System.Collections.Generic;

namespace ATM_MVC_App_Simple_Exmple_.Models;

public partial class CardHolder
{
    public int CardHolderId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string CardNumber { get; set; } = null!;

    public string Pinnumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public decimal? Amount { get; set; }
}
