using Game_Zone2.Models;
using Game_Zone2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Game_Zone2.Servece
{
    public class Gameserve : IGameserve
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
       // private readonly string path;

        public Gameserve(ApplicationDbContext context,
             IWebHostEnvironment webHostEnvironment)        
        {

            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}/{Filesittings.ImagePath}";
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.games
                .Include(g => g.category)
                .Include(g => g.Devices)    
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }
        public Game? GetGameById(int id)
        {
            return _context.games
               .Include(g => g.category)
               .Include(g => g.Devices)
               .ThenInclude(d => d.Device)
               .AsNoTracking()
               .SingleOrDefault(g =>g.ID==id);
        }
        public async Task Create(CreateGameFormViewModel model)
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
        public bool Delete(int id)
        {
            var game = _context.games.Find(id);
            if (game is null) 
                return false;
            //delete cover
            var coverPath = Path.Combine(_imagesPath, game.Cover);
            if (File.Exists(coverPath))
            {
                File.Delete(coverPath);
            }
            _context.Remove(game);
            _context.SaveChanges();
            return true;
        }

        public async Task<Game?> Update(EditeGameVM model)
        {
            var game = _context.games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.ID == model.ID);
            if (game is null) 
                return null;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDivec.Select(d => new GameDevice
            {
               DeviceId = d
            }).ToList();
            if (model.Cover is not null)
            {
                var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
                var path = Path.Combine(_imagesPath, coverName);
                using var stream = File.Create(path);
                await model.Cover.CopyToAsync(stream);
                //delete old cover
                var oldCoverPath = Path.Combine(_imagesPath, game.Cover);
                if (File.Exists(oldCoverPath))
                {
                    File.Delete(oldCoverPath);
                }
                game.Cover = coverName;
            }
            _context.Update(game);
            _context.SaveChanges();
            return game;
        }
    }
}
