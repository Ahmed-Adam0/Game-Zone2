using Game_Zone2.Models;
using Game_Zone2.ViewModels;

namespace Game_Zone2.Servece
{
    public class Gameserve : IGameserve
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
        private readonly string path;

        public  Gameserve(ApplicationDbContext context,
             IWebHostEnvironment webHostEnvironment)        
        {

            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{filesittings.ImagePath}";
        }
        public async Task create(CreateGameFormViewModel model)
        {
            var coverName= $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName);

            using var stream = File.Create(path);
             await model.Cover.CopyToAsync(stream);

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                Devices=model.SelectedDivec.Select(d => new GameDevice
                {
                    DeviceId = d
                }).ToList()
            };
            _context.Add(game);
            _context.SaveChanges();
        }

        public Task Create(CreateGameFormViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
