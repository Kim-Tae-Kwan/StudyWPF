using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace BasicChartApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChartValues<double> LineValues { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeChartData(); //Chart 초기화
        }

        private void InitializeChartData()
        {
            LineValues = new ChartValues<double> { 3, 5, 6.5, 12.3, 17.54, 0, 7, 9 }; //데이터 값.
            DataContext = this; //바인딩 소스.
        }
    }
}
