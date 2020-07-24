using System.Windows.Media;

namespace BusinessLogic
{
    public class Car : Notifier
    {

        private double speed;

        public double Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("speed");
            }
        }

        private Color color;

        public Color Color 
        { 
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDrivingLicense { get; set; }
    }
}
