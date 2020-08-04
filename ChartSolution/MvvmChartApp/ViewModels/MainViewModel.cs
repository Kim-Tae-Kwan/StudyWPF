using Caliburn.Micro;
using System;

namespace MvvmChartApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {

        public void ExitProgram() 
        {
            Environment.Exit(0); //프로그램 종료
        }

        public void LoadLineChart()
        {
            ActivateItem(new LineChartViewModel()); //LineChart 화면 표시
        }
        public void LoadGaugeChart()
        {
            ActivateItem(new GuageChartViewModel()); //GuageChart 화면 표시
        }
    }
}
