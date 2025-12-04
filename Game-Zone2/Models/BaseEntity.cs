using System.ComponentModel.DataAnnotations;

namespace Game_Zone2.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        [MaxLength(length: 230)]
        public string Name { get; set; } = string.Empty;
    }
}
