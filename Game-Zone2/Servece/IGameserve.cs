using Game_Zone2.ViewModels;
namespace Game_Zone2.Servece
{
    public interface IGameserve
    {
        internal Task SaveChanges(CreateGameFormViewModel model)
        {
            throw new NotImplementedException();
        }

        Task Create(CreateGameFormViewModel model);
    }
}
