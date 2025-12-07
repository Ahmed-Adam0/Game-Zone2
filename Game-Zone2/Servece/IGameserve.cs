using Game_Zone2.Models;
using Game_Zone2.ViewModels;
namespace Game_Zone2.Servece
{
    public interface IGameserve
    {
      
        IEnumerable<Game> GetAllGames();
        Game? GetGameById(int id);
        Task Create(CreateGameFormViewModel model);
        Task<Game?> Update(EditeGameVM model);
        bool Delete(int id);

    }
}
