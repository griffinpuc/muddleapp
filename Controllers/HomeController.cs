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


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(String userDrink)
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

        public IActionResult showRecipe(string drinkId, string userDrink)
        {

            string results = new Api().searchById(drinkId).Result;

            Drink drink = new Drink().deserializeDrinks(results)[0];
            if (_context.containsDrinkHit(drinkId))
            {
                Hit hit = _context.getHit(drinkId);
                hit.addHit();
                _context.UpdateEntry(hit);
            }
            else
            {
                Hit hit = new Hit { idDrink = drink.idDrink, hits = 1 };
                _context.AddEntry(hit);
            }
            

            Nugget nug = new Nugget()
            {
                drink = drink,
                userDrink = userDrink
            };

            return View(nug);

        }
    }
}
