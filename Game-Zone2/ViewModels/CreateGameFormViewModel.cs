using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game_Zone2.ViewModels
{
    public class CreateGameFormViewModel
    {
        public int ID { get; set; }
        [MaxLength(length: 230)]
        public string Name { get; set; } = string.Empty;
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categores { get; set; }=Enumerable.Empty<SelectListItem>();
        [Display(Name = "support devices")]
        public List<int> SelectedDivec  { get; set; }= default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        public IFormFile Cover { get; set; } = default!;
        [MaxLength(length: 2500)]
        public string Description { get; set; } = string.Empty;
        public object Categories { get; internal set; }
    }
}
