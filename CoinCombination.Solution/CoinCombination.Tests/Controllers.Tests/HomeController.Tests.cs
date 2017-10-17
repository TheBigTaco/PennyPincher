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
    }
}
