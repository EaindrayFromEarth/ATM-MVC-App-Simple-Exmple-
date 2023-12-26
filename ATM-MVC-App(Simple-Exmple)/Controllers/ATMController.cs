using ATM_MVC_App_Simple_Exmple_.Models;
using Microsoft.AspNetCore.Mvc;
using System;


public class ATMController : Controller
{
    private readonly AtmContext _context;

    public ATMController(AtmContext context)
    {
        _context = context;
    }

    public IActionResult EnterCardNumber()
    {
        return View();
    }

    [HttpPost]
    public IActionResult EnterCardNumber(string cardNumber)
    {
        var cardHolder = _context.CardHolders.FirstOrDefault(ch => ch.CardNumber == cardNumber);

        if (cardHolder == null)
        {
            ModelState.AddModelError("CardNumber", "Card Number not found");
            return View();
        }

        return RedirectToAction("MainMenu", new { cardHolder.CardHolderId });
    }

    public IActionResult EnterPin(int cardHolderId)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        return View(cardHolder);
    }

    [HttpPost]
    public IActionResult ValidatePin(int cardHolderId, string pin)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        if (cardHolder.Pinnumber == pin)
        {
            // PIN is valid, navigate to the main menu
            return RedirectToAction("MainMenu", new { cardHolderId });
        }
        else
        {
            // Invalid PIN, show error message
            ModelState.AddModelError("Pin", "Invalid PIN Number");
            return View("EnterPin", cardHolder);
        }
    }


    /*    public IActionResult EnterPIN(int cardHolderId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterPIN(int cardHolderId, string pinNumber)
        {
            var cardHolder = _context.CardHolders.Find(cardHolderId);

            if (cardHolder == null || cardHolder.Pinnumber != pinNumber)
            {
                ModelState.AddModelError("PINNumber", "Invalid PIN Number");
                return View();
            }

            return RedirectToAction("MainMenu", new { cardHolderId });
        }*/

    public IActionResult MainMenu(int cardHolderId)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        return View(cardHolder);
    }


    public IActionResult Deposit(int cardHolderId)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);
        return View(cardHolder);
    }

    [HttpPost]
    public IActionResult Deposit(int cardHolderId, decimal amount)
    {
        if (amount <= 0)
        {
            ModelState.AddModelError("Amount", "Please enter a valid amount");
            return View(_context.CardHolders.Find(cardHolderId));
        }

        var cardHolder = _context.CardHolders.Find(cardHolderId);
        cardHolder.Balance += amount;
        _context.SaveChanges();

        return RedirectToAction("MainMenu", new { cardHolderId });
    }

    public IActionResult Withdraw(int cardHolderId)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        if (cardHolder == null)
        {
            return RedirectToAction("EnterCardNumber");
        }

        return View(cardHolder);
    }

    [HttpPost]
    public IActionResult Withdraw(int cardHolderId, decimal amount)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        if (cardHolder == null)
        {
            return RedirectToAction("EnterCardNumber");
        }

        if (amount <= 0)
        {
            ModelState.AddModelError("Amount", "Withdrawal amount must be greater than zero.");
            return View(cardHolder);
        }

        if (amount > cardHolder.Balance)
        {
            ModelState.AddModelError("Amount", "Insufficient funds.");
            return View(cardHolder);
        }

        // Update the balance after withdrawal
        cardHolder.Balance -= amount;
        _context.SaveChanges();

        return RedirectToAction("MainMenu", new { cardHolderId });
    }

    public IActionResult CheckBalance(int cardHolderId)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        return View(cardHolder);
    }

    public IActionResult Exit()
    {
        return RedirectToAction("EnterCardNumber"); // Redirect to home or any other desired page
    }

}
