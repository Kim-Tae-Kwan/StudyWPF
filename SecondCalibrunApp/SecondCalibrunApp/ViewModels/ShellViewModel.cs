using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCalibrunApp.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }

        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";
            FirstName = "TaeKwan";
        }

        string firstName;
        public string FirstName 
        {
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        string lastName;
        public string LastName
        {
            get =>lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }

        
    }
}
