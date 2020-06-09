using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayCardDotnetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayCardDotnetCoreMVC.Controllers
{
    public class BirdayCardFormController : Controller
    {
        public IActionResult BirthdayCardForm()
        {
            return View();
        }

        public IActionResult SendBirthdayCard(BirthdayCardModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("BirthdayCardView",model);
            }
            return View("BirthdayCardForm", model);
        }
        public IActionResult BirthdayCardView(BirthdayCardModel model)
        {
            return View(model);
        }
    }
}