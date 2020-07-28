using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StartCaliburnApp.ViewModels
{
    public class ButtonsViewModel : Conductor<object>
    {
        public void ButtonClick()
        {
            MessageBox.Show("Basic Button Clicked");
        }

        public bool CanButtonClick
        {
            get => true;
        }

        public void Button2Click(object sender)
        {
            if (!(sender is Button)) return;
            Button btn = sender as Button;
            MessageBox.Show($"Button2Click : {btn.Content}");

        }
    }
}
