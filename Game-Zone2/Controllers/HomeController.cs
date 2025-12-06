using System.Diagnostics;
using Game_Zone2.Models;
using Game_Zone2.Servece;
using Microsoft.AspNetCore.Mvc;

namespace Game_Zone2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameserve _gameserve;

        public HomeController(IGameserve gameserve)
        {
            _gameserve = gameserve;
        }

        public IActionResult Index()
        {
             var games = _gameserve.GetAllGames();
            return View(games);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
