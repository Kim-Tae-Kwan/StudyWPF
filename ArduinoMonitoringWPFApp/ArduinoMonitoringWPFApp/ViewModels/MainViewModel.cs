using Caliburn.Micro;
using System;
using System.Threading;
using System.IO.Ports;
using System.Windows;
using ArduinoMonitoringWPFApp.Base;
using System.Collections.Generic;
using System.Windows.Media.Animation;

namespace ArduinoMonitoringWPFApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        #region 속성 영역
        readonly IWindowManager windowManager; //팝업창

        public bool IsSimulation { get; set; }
        SerialPort serial;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();

        Timer timer { get; set; }
        Random rand = new Random();
        public BindableCollection<string> CboSerialPort { get; set; }

        string connTime;
        public string ConnTime
        {
            get => connTime;
            set
            {
                connTime = value;
                NotifyOfPropertyChange(() => ConnTime);
            }

        }

        string sensorCount;
        public string SensorCount
        {
            get => sensorCount;
            set
            {
                sensorCount = value;
                NotifyOfPropertyChange(() => SensorCount);
            }
        }

        int pgbPhotoRegistor;
        public int PgbPhotoRegistor
        {
            get => pgbPhotoRegistor;
            set
            {
                pgbPhotoRegistor = value;
                NotifyOfPropertyChange(() => PgbPhotoRegistor);
            }
        }

        string lblPhotoRegistor;
        public string LblPhotoRegistor
        {
            get => lblPhotoRegistor;
            set
            {
                lblPhotoRegistor = value;
                NotifyOfPropertyChange(() => LblPhotoRegistor);
            }
        }

        string rtbLog;
        public string RtbLog
        {
            get => rtbLog;
            set
            {
                rtbLog = value;
                NotifyOfPropertyChange(() => RtbLog);
            }
        }

        string btnPortValue;
        public string BtnPortValue
        {
            get => btnPortValue;
            set
            {
                btnPortValue = value;
                NotifyOfPropertyChange(() => BtnPortValue);
            }
        }

        string selectedPort;
        public string SelectedPort
        {
            get => selectedPort;
            set
            {
                selectedPort = value;
                NotifyOfPropertyChange(() => SelectedPort);
            }
        }

        #endregion

        #region 생성자 영역
        public MainViewModel() //생성자
        {
            InitComboBox();
            ConnTime = "연결시간 :";
        }

        private void InitComboBox()
        {
            CboSerialPort = new BindableCollection<string>();
            CboSerialPort.Add("선택");
            foreach (var item in SerialPort.GetPortNames())
            {
                var temp = item;
                CboSerialPort.Add(temp);
            }
        }

        public void ProgramExit()
        {
            Environment.Exit(0);
        }
        #endregion

        private void DisplayValue(string sVal)
        {
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);

                SensorCount = photoDatas.Count.ToString();
                PgbPhotoRegistor = v;
                LblPhotoRegistor = v.ToString();
                string item = $"{photoDatas.Count} {DateTime.Now.ToString("yy-MM-dd hh:mm:ss")}\t{v}";
                RtbLog=$"{item}\n";

                if (IsSimulation == false)
                {
                    BtnPortValue = $"{serial.PortName}\n{sVal}";
                    //InsertDataToDB(data);
                }
                else
                    BtnPortValue = $"{sVal}";


            }
            catch (Exception ex)
            {
                //RtbLog.AppendText($"Error : {ex.Message}\n");
                //RtbLog.ScrollToEnd();
            }
        }

        public void BtnConnect()
        {
            if (IsSimulation)
            {
                MessageBox.Show("시뮬레이션을 중지하세요.");
                return;
            }
            else if (string.IsNullOrEmpty(SelectedPort))
            {
                MessageBox.Show("포트를 선택하세요.");
                return;
            }
            else if (serial == null)
            {

                string portNum = SelectedPort;
                serial = new SerialPort(portNum);
                serial.DataReceived += Serial_DataReceived;
                serial.Open();

                ConnTime = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
                //BtnConnect.IsEnabled = false;
                //BtnDisconnect.IsEnabled = true;
            }
            else
                MessageBox.Show("이미 연결되었습니다.");
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();

        }

        public void BtnDisconnect()
        {
            if (serial != null)
            {
                serial.Close();

                SelectedPort = CboSerialPort[0];
            }
            else
                MessageBox.Show("포트를 연결하세요.");
        }

        public void SimStart()
        {
            IsSimulation = true;
            timer = new Timer(TickCallBack);
            timer.Change(1000, 1000);
        }

        private void TickCallBack(object state)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }

        public void SimStop()
        {
            timer.Dispose();
            IsSimulation = false;
        }

        public void Info()
        {
            //InfoViewModel infoView = new InfoViewModel();
            //bool? success = windowManager.ShowDialog(infoView);
        }
    }
}
