using Game_Zone2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game_Zone2.Servece
{
    public class Categoresservice: ICategoresService
    {
        private readonly ApplicationDbContext _context;

        public Categoresservice(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.categories
                    .Select(C => new SelectListItem { Value = C.ID.ToString(), Text = C.Name })
                    .OrderBy(C => C.Text)
                    .AsNoTracking()
                    .ToList();
        }
    }
    
    
}
