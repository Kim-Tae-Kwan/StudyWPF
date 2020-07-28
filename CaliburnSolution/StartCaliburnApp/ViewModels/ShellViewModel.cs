using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StartCaliburnApp.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IHaveDisplayName // Caliburn 메소드 사용하기 위해서
    {
        string name;
        public string Name
        {
            get => name; //람다식
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name); //람다식
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello
        {
            get => !string.IsNullOrEmpty(Name);
        }
        public string DisplayName { get; set; }

        public ShellViewModel()
        {
            DisplayName = "Basic Caliburn App";
        }

        public void SayHello()
        {
            MessageBox.Show($"Hello {Name}");
        }
    }
}
