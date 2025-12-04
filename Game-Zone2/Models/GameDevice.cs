namespace Game_Zone2.Models
{
    public class GameDevice
    {
        public int GameId { get; set; } = default!;
        public Game Game { get; set; } = default!;  
        public int DeviceId { get; set; } = default!;
        
        public Device Device { get; set; } = default!;

    }
}
