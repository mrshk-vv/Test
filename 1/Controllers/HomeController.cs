using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using _1.Models;

namespace _1.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            int time = DateTime.Now.Hour;
            ViewBag.Greeting = time < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            Repository.AddResponse(guestResponse);

            return View("Thanks", guestResponse);
        }

        public ViewResult ListResponses()
        {

            if (ModelState.IsValid)
            {
                return View(Repository.Responses.Where(p => p.WillAttend == true));
            }
            else
            {
                return View();
            }
        }
    }
}
