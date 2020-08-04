using Caliburn.Micro;
using System;
using System.Threading;

namespace MvvmChartApp.ViewModels
{
    internal class GuageChartViewModel : Conductor<object>
    {
        double angValue;
        public double AngValue
        {
            get => angValue;
            set
            {
                angValue = value;
                NotifyOfPropertyChange(() => AngValue);
            }
        }

        public Timer CustomTimer { get; set; }

        public GuageChartViewModel()
        {
            CustomTimer = new Timer(TickCallBack);
            CustomTimer.Change(1000, 500);
        }

        private void TickCallBack(object state)
        {
            AngValue = new Random().Next(20, 300);
        }
    }
}