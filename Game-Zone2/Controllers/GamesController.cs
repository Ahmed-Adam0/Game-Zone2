using System.ComponentModel.Design;
using Game_Zone2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Game_Zone2.Servece;
using Game_Zone2.Controllers;

namespace Game_Zone2.Servece
{
    public class GamesController : Controller
    {
        private readonly ICategoresService _categoriesService;
        private readonly IDeviceServe _devicesService;
        private readonly IGameserve _gamesService;
        public GamesController(ICategoresService categoriesService,
            IDeviceServe devicesService,
            IGameserve gamesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        public IActionResult Index()
        {
            var games = _gamesService.GetAllGames();
            return View(games);
        }
        public IActionResult Details(int id)
        {
            var game = _gamesService.GetGameById(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewmodel = new()
            {
                Categores = _categoriesService.GetSelectionList(),
                Devices = _devicesService.GetSelectionList()
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectionList();
                model.Devices = _devicesService.GetSelectionList();
                return View(model);
            }

            await _gamesService.SaveChanges(model);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Eite(int id)
        {
            var game = _gamesService.GetGameById(id);
            if (game == null) return NotFound();
            EditeGameVM editeGameVM = new()
            {
                ID = game.ID,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                Categores = _categoriesService.GetSelectionList(),
                Devices = _devicesService.GetSelectionList(),
                SelectedDivec = game.Devices.Select(d => d.DeviceId).ToList(),
                currentCover = game.Cover
            };

            return View(editeGameVM);
        }
    }
}
