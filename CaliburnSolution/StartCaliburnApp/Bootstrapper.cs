using Caliburn.Micro;
using StartCaliburnApp.ViewModels;
using System.Windows;

namespace StartCaliburnApp
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize(); //초기화
        }
        protected override void OnStartup(object sender, StartupEventArgs e) 
        {
            //DisplayRootViewFor<object>(); // object -> ViewModel
            DisplayRootViewFor<ButtonsViewModel>(); // object -> ViewModel
        }
    }
}
