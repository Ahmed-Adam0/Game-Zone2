using Game_Zone2.Models;

namespace Game_Zone2.Servece
{
    public class DeviceServe : IDeviceServe
    {
        private readonly ApplicationDbContext _context;

        public DeviceServe(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implement the correct interface method
        public IEnumerable<SelectListItem> GetSelectionList()
        {
            return _context.devices
                    .Select(d => new SelectListItem { Value = d.ID.ToString(), Text = d.Name })
                    .OrderBy(d => d.Text)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
