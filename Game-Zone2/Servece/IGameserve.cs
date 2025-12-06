using Game_Zone2.Models;
using Game_Zone2.ViewModels;
namespace Game_Zone2.Servece
{
    public interface IGameserve
    {
        internal Task SaveChanges(CreateGameFormViewModel model)
        {
            throw new NotImplementedException();
        } 
        IEnumerable<Game> GetAllGames();
        Game? GetGameById(int id);
        Task Create(CreateGameFormViewModel model);
        object GetById(int id);
    }
}
