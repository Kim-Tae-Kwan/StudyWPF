using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ArduinoMonitoringWPFApp
{

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        SerialPort serial;

        private short xCount = 200;
        private short maxPhotoVal = 1023;
        private int time = 0;
        List<SensorData> photoDatas = new List<SensorData>();
        public bool IsSimulation { get; set; }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            InitialControls();
            graphInit();
        }
        private void graphInit() 
        {
            Chart chartView = new Chart(); 
            Title title = new System.Windows.Forms.DataVisualization.Charting.Title(); 
            title.Text = "photo value"; 
            chartView.Titles.Add(title); 

            ChartArea chartArea = new ChartArea(); 
            chartArea.Name = "Safety"; 
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount; 
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.Maximum = 100;
            chartView.ChartAreas.Add(chartArea); Series series = new Series(); 
            series.ChartArea = "Safety"; 
            series.BackGradientStyle = GradientStyle.TopBottom; 
            series.ChartType = SeriesChartType.Column; 
            series.XValueType = ChartValueType.String;
            series.IsValueShownAsLabel = true; 
            chartView.Series.Add(series); Legend legend = new Legend(); 
            legend.Enabled = false;
            chartView.Legends.Add(legend);

            chart.Child = chartView;

            
        }

        


        private void InitialControls()
        {
            
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(item);
            }
            CboSerialPort.Text = "Select Port";

            PgbPhotoRegistor.Minimum = 0;
            PgbPhotoRegistor.Maximum = maxPhotoVal;

            BtnConnect.IsEnabled = BtnDisconnect.IsEnabled = false;
        }

        private void CboSerialPort_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var portName = CboSerialPort.SelectedItem.ToString();
            serial = new SerialPort(portName);
            serial.DataReceived += Serial_DataReceived;

            BtnConnect.IsEnabled = true;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            this.BeginInvoke(new Action(delegate { DisplayValue(sVal); }));
        }

        private void DisplayValue(string sVal)
        {
            
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);
                //InsertDataToDB(data);
                TxtSensorCount.Text = photoDatas.Count.ToString();
                PgbPhotoRegistor.Value = v;
                LblPhotoRegistor.Text = v.ToString();

                string item = $"{photoDatas.Count} {DateTime.Now.ToString("yy-MM-dd hh:mm:ss")}\t{v}";

               
                RtbLog.AppendText($"{item}\n");
                RtbLog.ScrollToEnd();


                //ChtSensorValues.Series[0].Points.Add(v);

                //ChtSensorValues.ChartAreas[0].AxisX.Minimum = 0;
                //ChtSensorValues.ChartAreas[0].AxisX.Maximum =
                //    (photoDatas.Count >= xCount) ? photoDatas.Count : xCount;

                //if (photoDatas.Count > xCount)
                //    ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(
                //        photoDatas.Count - xCount, photoDatas.Count);
                //else
                //    ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(0, xCount);

                if (IsSimulation == false)
                    BtnPortValue.Content = $"{serial.PortName}\n{sVal}";
                else
                    BtnPortValue.Content = $"{sVal}";
            }
            catch (Exception ex)
            {
                RtbLog.AppendText($"Error : {ex.Message}\n");
                RtbLog.ScrollToEnd();
            }
        }

        private void BtnConnect_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (IsSimulation == true)
                System.Windows.Forms.MessageBox.Show("시뮬레이션을 중지 하세요.","알림",MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (serial!=null && IsSimulation==false)
            {
                serial.Open();
                ConnTime.Text = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
                BtnConnect.IsEnabled = false;
                BtnDisconnect.IsEnabled = true;
            }

        }

        private void BtnDisconnect_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (serial !=null && serial.IsOpen == true)
            {
                serial.Close();
                BtnConnect.IsEnabled = true;
                BtnDisconnect.IsEnabled = false;
            }
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItemStart_Click(object sender, RoutedEventArgs e)
        {
            IsSimulation = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            // serial통신 끊기
            BtnDisconnect_Click(sender, e);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
            time++;
        }
        

        private void MenuItemStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            IsSimulation = false;

            // serial 통신 재시작
            BtnConnect_Click(sender, e);
        }
    }
}
