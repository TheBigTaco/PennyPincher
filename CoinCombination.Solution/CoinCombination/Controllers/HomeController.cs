using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CoinCombination.Models;

namespace CoinCombination.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpPost("/combo")]
      public ActionResult Combo()
      {

          Coin newCoin = new Coin(double.Parse(Request.Form["money-input"]));
          List<int> coinAmounts = newCoin.Gatekeeper(newCoin);
          return View(coinAmounts);
      }
    }

}
