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
        var cardHolder = _context.CardHolders.SingleOrDefault(ch => ch.CardNumber == cardNumber);

        if (cardHolder == null)
        {
            ModelState.AddModelError("CardNumber", "Card Number not found");
            return View();
        }

        return RedirectToAction("EnterPIN", new { cardHolder.CardHolderId });
    }

    public IActionResult EnterPIN(int cardHolderId)
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
    }

    public IActionResult MainMenu(int cardHolderId)
    {
        var cardHolder = _context.CardHolders.Find(cardHolderId);

        return View(cardHolder);
    }


}
