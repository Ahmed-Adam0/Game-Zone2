using System.ComponentModel.Design;
using Game_Zone2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Game_Zone2.Servece;

namespace Game_Zone2.Controllers
{
    public class GamesController(ICategoriesService categoriesService, IDeviceServe devicesService, IGameserve gamesService) : Controller
    {
      private  readonly ICategoriesService _categoriesService = categoriesService;
        private  readonly IDeviceServe _devicesService = devicesService;
        private readonly IGameserve _gamesService = gamesService;
        private object _dbContext;

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create() 
        {        
            CreateGameFormViewModel viewmodel = new ()
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

             await _gamesService.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
