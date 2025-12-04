using System.ComponentModel.Design;
using Game_Zone2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Game_Zone2.Servece;
using Game_Zone2.Controllers;

namespace Game_Zone2.Servece
{
    public class GamesController: Controller
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
            return View();
        }
        [HttpGet]
        public IActionResult Create() 
        {        
            CreateGameFormViewModel viewmodel = new ()
            {
                Categores = (IEnumerable<SelectListItem>)_categoriesService.GetSelectionList(),
                Devices = _devicesService.GetSelectionList()
            };
            return View(viewmodel); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(CreateGameFormViewModel model)
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
    }
}
