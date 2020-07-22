using System.Windows.Media;

namespace BusinessLogic
{
    public class Car
    {
        public double Speed { get; set; }
        public Color Color { get; set; }
        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDrivingLicense { get; set; }
    }
}
