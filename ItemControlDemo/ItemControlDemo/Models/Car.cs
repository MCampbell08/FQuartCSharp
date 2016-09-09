using ItemControlDemo.Enums;

namespace ItemControlDemo.Models
{
    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DriveTrain DriveTrainType { get; set; }
        public bool HasAC { get; set; }
    }
}
