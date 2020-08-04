using Caliburn.Micro;
using LiveCharts;

namespace MvvmChartApp.ViewModels
{
    class LineChartViewModel : Conductor<object>
    {
        ChartValues<double> lineValues;
        public ChartValues<double> LineValues
        {
            get => lineValues;
            set
            {
                lineValues = value;
                NotifyOfPropertyChange(() => LineValues);
            }
        }

        public LineChartViewModel()
        {
            InitializeChartData(); //Chart 초기화
        }

        private void InitializeChartData()
        {
            LineValues = new ChartValues<double> { 3, 5, 6.5, 12.3, 17.54, 0, 7, 9 }; //데이터 값.
            
        }
    }
}
