using Microsoft.AspNetCore.Mvc;
using TSD2491_oblig1_255008.Models;
using System.Diagnostics;
using TSD2491_oblig1_255008;

namespace TSD2491_oblig1_255008
{
    public class HomeController : Controller
    {
        private readonly static MatchingGameModels _matchingGameModels = new MatchingGameModels();


        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View(_matchingGameModels);
        }

        [HttpPost]
        public IActionResult ButtonClick(string animal, string description)
        {
            _matchingGameModels.ButtonClick(animal, description);
            return View("Index", _matchingGameModels);
        }
    }
}