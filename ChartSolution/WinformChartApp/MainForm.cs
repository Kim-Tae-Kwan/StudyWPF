using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Forms;

namespace WinformChartApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SeriesCollection piechartData = new SeriesCollection()
            {
                new PieSeries
                {
                    Title = "삼성전자",
                    Values = new ChartValues<double> {75.5},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "LG전자",
                    Values = new ChartValues<double> {24.1},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "대우전자",
                    Values = new ChartValues<double> {5.3},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "삼화전자",
                    Values = new ChartValues<double> {1.5},
                    DataLabels = true,
                }
            };

            pieChart1.Series = piechartData; //파이차트에 데이터 입력.
            pieChart1.LegendLocation = LegendLocation.Right; //범례위치 설정.
        }
    }
}
