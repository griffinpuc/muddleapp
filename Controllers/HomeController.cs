using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muddleapp.Models;

namespace muddleapp.Controllers
{
    public class HomeController : Controller
    {

        public databaseContext _context;

        public HomeController(databaseContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            Drink[] topDrinks = _context.getTop();
            return View(new Nugget() { drinks = topDrinks }) ;
        }

        public IActionResult searchPath(string userDrink)
        {
            return Redirect("/Home/Search?userDrink=" + userDrink);
        }

        public ActionResult Search(string userDrink)
        {

            string results = new Api().searchDrinksAsync(userDrink).Result;

            Drink[] drinks = new Drink().deserializeDrinks(results);

            Nugget nug = new Nugget()
            {
                drinks = drinks,
                userDrink = userDrink
            };

            return View(nug);
        }

        public IActionResult Recipe(string drinkId)
        {

            _context.addHit(drinkId);

            string results = new Api().searchById(drinkId).Result;

            Drink drink = new Drink().deserializeDrinks(results)[0];
            
            Nugget nug = new Nugget()
            {
                drink = drink
            };

            return View(nug);

        }
    }
}
