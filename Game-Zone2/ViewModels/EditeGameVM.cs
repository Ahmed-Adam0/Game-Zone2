using Game_Zone2.Attributes;

namespace Game_Zone2.ViewModels
{
    public class EditeGameVM
    {
        public int ID { get; set; }
        [MaxLength(length: 230)]
        public string? currentCover { get; set; }
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categores { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "support devices")]
        public List<int> SelectedDivec { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(length: 2500)]
        public string Description { get; set; } = string.Empty;
        public object Categories { get; internal set; } = null!;

        [AllowExtentions(Filesittings.allowedExtensions)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
